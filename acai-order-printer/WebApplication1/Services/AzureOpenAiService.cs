using OpenAI.Chat;

namespace WebApplication1.Services;

public class AzureOpenAiService(ChatClient chatClient)
{
    public async Task<string> AnalyzeAcaiOrder(string documentIntelligenceResponse)
    {
        ChatCompletion completion = await chatClient.CompleteChatAsync(
        [
            new SystemChatMessage(@"
                Voce é um assistente especializado em gerar um pedido de açai.
                O Input será um json vindo da transformação da imagem em Texto e eu preciso que voce liste alguns campos de texto livre e principalmente as seleções.

                Eu quero que voce extraia para mim o Nome e o Telefone do pedido, que estara escrito de forma livre.

                Depois quero que você me liste as seguintes seleções:
                - Pagamento Selecionado (Dinheiro, Cartão ou Pix) e se precisa de troco caso a opção selecionada seja dinheiro.
                - Informar se é para viagem ou consumir no local caso a opção de viagem esteja desmarcada
                - tamanho selecionado (PP, P, M, G ou GG)
                - qual o tipo do açai (Tradicional, Creme Cupuaçu ou Mix)
                - os adicionais: Ganola, Leite em pó, Leite Condensado, Chantily de Ninho, Paçoca, Jujuba, ChocoBall, M&M, Flocos de Chocolate, Gotas de Chocolate, Ovomaltine e Nutella
                - as frutas: Morango, Banana, Uva
                - as caldas: Morango e Chocolate
                - e os adicionais especiais: Bis, Baton, Chantily, Biscoito Oreo

                A saida deve ser em JSON e não pode conter caracteres especiais nas propriedades, por exemplo Método deve vir como Metodo. 
                Adicionais, Frutas, Caldas, AdicionaisEspeciais devem ser listas de strings com apenas o nome dos itens selecionados
            "),
            // ------------------------------------------------------------------------------------------------------------------------------------
            new UserChatMessage(documentIntelligenceResponse)
        ], options: new ChatCompletionOptions
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "acai_order",
                jsonSchema: BinaryData.FromObjectAsJson(new
                {
                    type = "object",
                    properties = new
                    {
                        Nome = new { type = "string" },
                        Telefone = new { type = "string" },
                        Pagamento = new
                        {
                            type = "object",
                            properties = new
                            {
                                Metodo = new { type = "string" },
                                Troco = new { type = "boolean" }
                            }
                        },
                        ParaViagem = new { type = "boolean" },
                        Tamanho = new { type = "string" },
                        TipoAcai = new { type = "string" },
                        Adicionais = new { type = "array", items = new { type = "string" } },
                        Frutas = new { type = "array", items = new { type = "string" } },
                        Caldas = new { type = "array", items = new { type = "string" } },
                        AdicionaisEspeciais = new { type = "array", items = new { type = "string" } }
                    }
                })
            )
        });

        return completion.Content[0].Text;
    }
}