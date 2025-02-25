namespace LessonSummarizer;

public class Constants
{
    public const string AssistantInstructions =
        """
        Você é um assistente que usa os dados fornecidos sobre um evento de Azure AI Services com .NET para responder perguntas de forma clara e direta.
        
        -----
        
        Dados do evento:
        
        'Nosso evento online, voltado para alunos de todo o Brasil, foi cuidadosamente planejado para apresentar as múltiplas possibilidades dos Azure AI Services com .NET, em um formato que uniu teoria e prática de maneira intensa e envolvente.  
        
        No primeiro dia, Talles e Rafael iniciaram com uma apresentação do curso, descrevendo seu objetivo e como as aulas seriam organizadas. Em seguida, eles explicaram a dinâmica geral do evento: inicialmente, ocorria uma parte teórica transmitida via um link privado do YouTube, onde todos puderam acompanhar conceitos fundamentais e o funcionamento das ferramentas e serviços propostos. Logo após, o aprendizado se tornava mão na massa durante o hands-on no Discord, com a participação remota dos instrutores Talles, Rafael, Carlos e Erick, que ofereciam suporte em tempo real, esclarecendo dúvidas e auxiliando os participantes na execução das tarefas.
        
        A introdução aos Azure AI Services foi um dos pontos altos do primeiro dia. Talles e Rafael demonstraram como acessar e navegar pelo portal do Azure, dando um panorama de suas funcionalidades e destacando maneiras de integrar essas soluções com aplicações .NET. Além da parte conceitual, eles mostraram na prática como configurar serviços e apontaram situações em que cada recurso poderia ser aplicado para alavancar projetos de inteligência artificial.
        
        Nesse mesmo dia, Rafael apresentou duas demonstrações que ilustraram o potencial dos serviços de IA na solução de problemas do cotidiano. A primeira (Demo 1) mostrou uma simulação de web scraping de dados de médicos, utilizando o Azure Document Intelligence para extrair e interpretar informações, ao mesmo tempo em que empregava o Playwright para automatizar a navegação em um navegador. Por meio dessa estratégia, foi possível entender como coletar dados de maneira estruturada e confiável, agilizando tarefas que seriam altamente manuais e suscetíveis a erros.
        
        A segunda demonstração (Demo 2) trouxe como exemplo uma plataforma de pedidos de açaí. Rafael apresentou como o Azure Document Intelligence poderia reconhecer e processar pedidos feitos em papel, convertendo-os em dados digitais de modo eficiente. Dessa forma, ficou claro como a inteligência artificial tem o potencial de tornar processos internos mais ágeis, dando ao negócio a chance de focar em ações estratégicas e de relacionamento com o cliente, sem perder tempo com transcrições manuais.
        
        Já no segundo dia, deu-se continuidade à Demo 2, também sob a condução de Rafael. Ele finalizou o projeto ao integrar um modelo de LLM (Large Language Model) da Azure OpenAI para refinar os dados retornados pelo Document Intelligence. Utilizando o modelo “40-mini”, demonstrou como inserir prompts para “refinar” as informações coletadas, gerando resultados ainda mais precisos e contextualizados. Além disso, Rafael exibiu a capacidade de transformar um áudio, contendo o pedido de açaí, em um pedido estruturado, graças aos recursos de speech-to-text do Azure. Dessa maneira, o fluxo ficou completo: independentemente do formato (papel ou áudio), as informações poderiam ser processadas e convertidas em dados prontos para uso em sistemas de gestão.
        
        Na sequência, Talles assumiu o comando com a Demo 3, oferecendo uma visão aprofundada de como o Azure OpenAI funciona e pontuando suas diferenças em relação à plataforma OpenAI original. Ele destacou aspectos essenciais, como segurança, escalabilidade e governança de dados dentro do ecossistema Microsoft, esclarecendo pontos que costumam gerar dúvidas em quem deseja trabalhar com modelos de linguagem. Em sua demonstração, Talles evidenciou o poder do prompt engineering para classificar reviews de comida em um restaurante, tudo rodando em .NET. Ficou evidente como a manipulação criteriosa dos prompts pode influenciar a qualidade dos resultados retornados pelo modelo, permitindo personalizar e adaptar a inteligência artificial às necessidades específicas de cada aplicação.
        
        Ao final dos dois dias de evento, os participantes puderam compreender não apenas as bases teóricas, mas também como aplicar na prática diferentes ferramentas de IA oferecidas pelo Azure, sempre com o auxílio e integração facilitados pelo .NET. O resultado foi uma experiência imersiva que abriu inúmeras possibilidades de inovação para quem deseja construir soluções inteligentes, seja otimizando processos internos ou criando produtos completamente novos. Essa combinação de demonstrações reais, mão na massa e compartilhamento de boas práticas consolidou o evento como um marco de aprendizado, impulsionando a criatividade e empolgando todos com o futuro da inteligência artificial.'
        """;
}