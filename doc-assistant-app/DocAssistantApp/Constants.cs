using System.Reflection.Metadata;

namespace DocAssistantApp;

public class Constants
{
    public const string AssistantInstructions =
        """
        You are a helpful assistant that can help fetch data from files you know about".
        If you do not find any content in the files, you must answer with a default message: 'EU NÃO SEI NADA SOBRE ISSO!'.
        """;
    
    public const string FileName = "Doc.md";
    
    public const string FileContent =
        """
        # O que é o Serviço OpenAI do Azure?
        
        ## Artigo
        **Publicado em:** 11/11/2024  
        **Colaboradores:** 10  
        
        ---
        
        ## Índice
        - [IA Responsável](#ia-responsável)
        - [Introdução ao Serviço OpenAI do Azure](#introdução-ao-serviço-openai-do-azure)
        - [Comparar o OpenAI do Azure e o OpenAI](#comparar-o-openai-do-azure-e-o-openai)
        - [Conceitos Principais](#conceitos-principais)
        - [Próximas Etapas](#próximas-etapas)
        
        ---
        
        ## IA Responsável
        A Microsoft está comprometida com o avanço da IA baseado em princípios que colocam as pessoas em primeiro lugar. O uso responsável de IA no Azure inclui:
        - Filtros de conteúdo para prevenir abusos.
        - Diretrizes de IA responsável.
        - Código de conduta para o serviço.
        
        ---
        
        ## Introdução ao Serviço OpenAI do Azure
        O Serviço OpenAI do Azure fornece acesso à API REST e SDKs para os modelos de linguagem avançados da OpenAI, como:
        - GPT-4o
        - GPT-4 Turbo com Visão
        - GPT-3.5-Turbo
        - Modelos de Embeddings
        
        ### Recursos:
        - **Ajuste fino:** disponível para modelos como GPT-4o-mini e GPT-3.5-Turbo.
        - **Rede virtual e link privado:** suportados.
        - **Interface do usuário:** via Portal do Azure e Estúdio de IA do Azure.
        
        #### Como começar:
        1. **Criar um recurso:** Use o portal do Azure, CLI ou PowerShell.
        2. **Implantar um modelo:** Escolha um modelo para usar na API.
        3. **Explorar recursos:** Experimente os playgrounds do Estúdio de IA ou chame APIs.
        
        ---
        
        ## Comparar o OpenAI do Azure e o OpenAI
        O OpenAI do Azure combina os modelos avançados do OpenAI com:
        - Segurança do Azure.
        - Suporte a rede privada.
        - Disponibilidade regional.
        - Filtragem de conteúdo de IA responsável.
        
        Os clientes podem usar a mesma API em ambas as plataformas, garantindo compatibilidade.
        
        ---
        
        ## Conceitos Principais
        ### Solicitações e Conclusões
        - **Ponto de extremidade:** fornece uma interface para entrada/saída do modelo.
        - **Exemplo:**
          - **Prompt:** `count to 5 in a for loop`
          - **Conclusão:** `for i in range(1, 6): print(i)`
        
        ### Tokens
        - **Texto:** Dividido em partes menores. Ex.: "hambúrguer" = "ham", "bur", "ger".
        - **Imagem:** Calculado com base nos detalhes e dimensões da imagem.
        
        #### Exemplo de cálculo de tokens:
        - **Imagem com muitos detalhes:**
          - **Modelo:** GPT-4 Turbo com Visão.
          - **Dimensão inicial:** 2048x4096 pixels.
          - **Cálculo:** 6 peças x 170 tokens + 85 tokens base = **1.105 tokens**.
        
        ---
        
        ## Engenharia de Prompt
        Os modelos GPT são baseados em prompts, e o design do prompt influencia diretamente a resposta do modelo.
        
        ### Dicas:
        - Teste e ajuste prompts para obter melhores resultados.
        - Considere a sensibilidade do modelo ao contexto.
        
        ---
        
        ## Modelos Disponíveis
        ### Texto
        - GPT-3, GPT-3.5, GPT-4 (versões com ajuste fino disponíveis).
          
        ### Imagem
        - Modelos DALL-E: Geram imagens a partir de texto.
        
        ### Fala
        - Whisper: Transcrevem e traduzem fala em texto.
        - Texto para Fala: Convertem texto em áudio.
        
        ---
        
        ## Próximas Etapas
        - Explore os modelos disponíveis no OpenAI do Azure.
        - Aprenda mais no [guia oficial de modelos](#).
        
        ----------------------
        
        # Visão geral do Serviço de Aplicativos
        **Artigo**  
        *16/10/2024*  
        **28 colaboradores**
        
        ---
        
        ## Neste artigo
        - [Por que usar o Serviço de Aplicativo?](#por-que-usar-o-serviço-de-aplicativo)
        - [Serviço de Aplicativo no Linux](#serviço-de-aplicativo-no-linux)
        - [Ambiente do Serviço de Aplicativo](#ambiente-do-serviço-de-aplicativo)
        - [Próxima etapa](#próxima-etapa)
        
        ---
        
        > **Observação**  
        > A partir de 1º de junho de 2024, todos os aplicativos recém-criados do Serviço de Aplicativo terão a opção de gerar um nome do host padrão exclusivo usando a convenção de nomenclatura `<app-name>-<random-hash>.<region>.azurewebsites.net`. Os nomes de aplicativos existentes permanecerão inalterados.  
        > **Exemplo:** `myapp-ds27dh7271aah175.westus-01.azurewebsites.net`  
        > Para obter mais detalhes, consulte [Nome do Host Padrão Exclusivo para o Recurso do Serviço de Aplicativo](#).
        
        ---
        
        O **Serviço de Aplicativo do Azure** é um serviço baseado em HTTP para hospedar aplicativos Web, APIs REST e back-ends móveis. Suporte para várias linguagens, incluindo **.NET, .NET Core, Java, Node.js, PHP e Python**, com execução em ambientes **Windows** e **Linux**.  
        Benefícios incluem: **segurança aprimorada, balanceamento de carga, dimensionamento automático e gerenciamento automatizado**, além de recursos de **DevOps**.
        
        **Modelo de precificação:**  
        Paga-se pelos recursos do **Plano do Serviço de Aplicativo** utilizados. Para mais detalhes, confira [Visão geral dos Planos do Serviço de Aplicativo do Azure](#).
        
        ---
        
        ## Por que usar o Serviço de Aplicativo?
        
        ### Principais recursos
        - **Variedade de linguagens e estruturas**: ASP.NET, Java, Node.js, PHP, Python, entre outros.
        - **Ambiente gerenciado**: Atualizações automáticas de SO e frameworks.
        - **Suporte a contêineres**: Imagens personalizadas e sidecars em Docker.
        - **Otimização DevOps**: CI/CD com GitHub, Azure DevOps, entre outros.
        - **Escalabilidade global**: Dimensionamento automático e alta disponibilidade.
        - **Conexões híbridas**: Integração com SaaS e dados locais.
        - **Segurança e conformidade**: ISO, SOC e PCI.
        - **Autenticação**: Com suporte a Microsoft Entra ID, Google, Facebook, e mais.
        - **Modelos de aplicativos**: Disponíveis no Azure Marketplace.
        - **Integração de ferramentas**: Suporte ao Visual Studio, IntelliJ, Maven, etc.
        - **Código sem servidor**: Azure Functions para execuções sob demanda.
        
        ---
        
        ## Serviço de Aplicativo no Linux
        
        O Serviço de Aplicativo no Linux suporta:
        - **Linguagens internas**: Node.js, Java, PHP, Python, .NET Core.
        - **Imagens personalizadas**: Opção para criar contêineres.
        
        ### Limitações
        - Não disponível no tipo de preço **Compartilhado**.
        - **Armazenamento Azure** com latência variável. Para alta performance, use contêineres personalizados.
        
        ---
        
        ## Ambiente do Serviço de Aplicativo
        
        O **Ambiente do Serviço de Aplicativo (ASE)** oferece:
        - **Isolamento completo**.
        - **Segurança aprimorada**.
        - **Alta escala** para workloads intensivas.
        
        > Para mais detalhes, consulte a [comparação entre ASE e Serviço de Aplicativo](#).
        
        ---
        
        ## Próxima etapa
        Explore os recursos avançados do Serviço de Aplicativo e escolha a configuração ideal para sua aplicação no Azure.
        
        ----------------------
        
        # O que é o SQL Azure?
        **Artigo**  
        *27/09/2024*  
        **20 colaboradores**
        
        ---
        
        ## Neste artigo
        - [Visão geral](#visão-geral)
        - [Comparação de serviço](#comparação-de-serviço)
        - [Tabela de comparação](#tabela-de-comparação)
        - [Custo](#custo)
        - [Administração](#administração)
        - [SLA (Contrato de Nível de Serviço)](#sla-contrato-de-nível-de-serviço)
        - [Tempo para mover para o Azure](#tempo-para-mover-para-o-azure)
        - [Criar e gerenciar recursos de SQL do Azure com o portal do Azure](#criar-e-gerenciar-recursos-de-sql-do-azure-com-o-portal-do-azure)
        
        ---
        
        ## Visão geral
        O **SQL do Azure** é uma família de produtos gerenciados, seguros e inteligentes que usam o mecanismo de banco de dados do SQL Server na nuvem Azure. Ele oferece migração fácil, continuidade no uso das ferramentas conhecidas e aproveita as habilidades já existentes para maximizar o potencial de soluções em nuvem.
        
        Os produtos incluem:
        1. **Banco de Dados SQL do Azure**: serviço de banco de dados inteligente e gerenciado.
        2. **Instância Gerenciada de SQL do Azure**: instância como serviço inteligente para migração em escala.
        3. **SQL Server em VMs do Azure**: controle total com lift-and-shift de workloads do SQL Server.
        
        ---
        
        ## Comparação de serviço
        
        ### Opções disponíveis:
        - **Banco de Dados SQL do Azure**: Melhor para aplicativos de nuvem modernos e desenvolvimento ágil.
        - **Instância Gerenciada de SQL do Azure**: Ideal para lift-and-shift com mínima alteração.
        - **SQL Server em VMs do Azure**: Perfeito para acesso ao sistema operacional e controle total.
        
        ---
        
        ## Tabela de comparação
        | **Recurso**                      | **Banco de Dados SQL**          | **Instância Gerenciada de SQL** | **SQL Server em VMs**          |
        |-----------------------------------|----------------------------------|----------------------------------|----------------------------------|
        | **Compatibilidade**               | Alta no nível do banco          | Alta no nível da instância       | Total                          |
        | **SLA**                           | 99,995%                         | 99,99%                          | Até 99,99%                     |
        | **Controle**                      | Gerenciado pelo Azure           | Parcialmente gerenciado          | Controle total                 |
        | **Backups e recuperação**         | Automáticos                     | Automáticos                     | Manuais ou automatizados       |
        | **Alteração de recursos**         | Online                          | Online                          | Requer tempo de inatividade    |
        | **Melhor uso**                    | Aplicativos modernos            | Migração para a nuvem            | Workloads complexos            |
        
        ---
        
        ## Custo
        Os custos variam conforme o modelo (PaaS ou IaaS) e as configurações escolhidas.  
        - **Banco de Dados SQL e Instância Gerenciada de SQL**: Preço por hora com recursos pré-configurados e administrados pelo Azure.
        - **SQL Server em VMs**: Controle total sobre os custos de licenciamento e infraestrutura.
        
        > Para calcular os custos, use a [Calculadora de preços do Azure](https://azure.microsoft.com/pt-br/pricing/calculator/).
        
        ---
        
        ## Administração
        - **Banco de Dados SQL e Instância Gerenciada de SQL**: Administração simplificada, sem necessidade de gerenciar sistema operacional ou atualizações.
        - **SQL Server em VMs**: Controle total do sistema operacional e instância, mas maior responsabilidade administrativa.
        
        ---
        
        ## SLA (Contrato de Nível de Serviço)
        - **Banco de Dados SQL e Instância Gerenciada de SQL**: SLA de disponibilidade de 99,99%.
        - **SQL Server em VMs**: SLA de 99,95% a 99,99%, dependendo da configuração de alta disponibilidade.
        
        ---
        
        ## Tempo para mover para o Azure
        - **Banco de Dados SQL do Azure**: Ideal para novos aplicativos projetados para a nuvem.
        - **Instância Gerenciada de SQL**: Simplifica a migração com mínima alteração.
        - **SQL Server em VMs**: Perfeito para migração lift-and-shift sem necessidade de reestruturar aplicativos.
        
        ---
        
        ## Criar e gerenciar recursos de SQL do Azure com o portal do Azure
        O portal do Azure permite criar e gerenciar recursos do SQL do Azure, como:
        - Bancos de Dados SQL
        - Instâncias Gerenciadas de SQL
        - Máquinas virtuais do SQL Server
        
        > **Observação**  
        > O SQL do Azure é uma família de serviços e não um recurso único. Para criar novos recursos, selecione **+ Criar** no portal do Azure.
        
        ---
        
        ## Conteúdo relacionado
        - [Criar um Banco de Dados SQL do Azure](https://azure.microsoft.com/pt-br/services/sql-database/)
        - [Migrar para o SQL do Azure](https://learn.microsoft.com/pt-br/azure/sql-database/sql-database-migration-guidance)
        - [Preços do Banco de Dados SQL](https://azure.microsoft.com/pt-br/pricing/details/sql-database/)
        
        """;

}