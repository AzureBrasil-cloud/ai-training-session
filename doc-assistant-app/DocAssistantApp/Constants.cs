using System.Reflection.Metadata;

namespace DocAssistantApp;

public class Constants
{
    public const string AssistantInstructions =
        """
        You are a helpful assistant that can help fetch data from files you know about".
        """;
    
    public const string FileName = "Doc.md";
    
    public const string FileContent =
        """
        # What is the Azure OpenAI Service?
        
        ## Article
        **Published on:** 11/11/2024  
        **Contributors:** 10  
        
        ---
        
        ## Index
        - [Responsible AI](#responsible-ai)
        - [Introduction to Azure OpenAI Service](#introduction-to-azure-openai-service)
        - [Compare Azure OpenAI and OpenAI](#compare-azure-openai-and-openai)
        - [Key Concepts](#key-concepts)
        - [Next Steps](#next-steps)
        
        ---
        
        ## Responsible AI
        Microsoft is committed to advancing AI based on principles that put people first. Responsible use of AI on Azure includes:
        - Content filters to prevent abuse.
        - Responsible AI guidelines.
        - Service code of conduct.
        
        ---
        
        ## Introduction to Azure OpenAI Service
        Azure OpenAI Service provides access to the REST API and SDKs for OpenAI's advanced language models, such as:
        - GPT-4o
        - GPT-4 Turbo with Vision
        - GPT-3.5-Turbo
        - Embedding Models
        
        ### Features:
        - **Fine-tuning:** Available for models like GPT-4o-mini and GPT-3.5-Turbo.
        - **Virtual network and private link:** Supported.
        - **User interface:** Available via Azure Portal and Azure AI Studio.
        
        #### How to get started:
        1. **Create a resource:** Use the Azure portal, CLI, or PowerShell.
        2. **Deploy a model:** Choose a model to use in the API.
        3. **Explore features:** Try the AI Studio playgrounds or call APIs.
        
        ---
        
        ## Compare Azure OpenAI and OpenAI
        Azure OpenAI combines OpenAI’s advanced models with:
        - Azure security.
        - Private network support.
        - Regional availability.
        - Responsible AI content filtering.
        
        Customers can use the same API on both platforms, ensuring compatibility.
        
        ---
        
        ## Key Concepts
        ### Requests and Completions
        - **Endpoint:** Provides an interface for model input/output.
        - **Example:**
          - **Prompt:** `count to 5 in a for loop`
          - **Completion:** `for i in range(1, 6): print(i)`
        
        ### Tokens
        - **Text:** Split into smaller parts. E.g., "hamburger" = "ham", "bur", "ger."
        - **Image:** Calculated based on details and dimensions.
        
        #### Example of token calculation:
        - **Highly detailed image:**
          - **Model:** GPT-4 Turbo with Vision.
          - **Initial dimension:** 2048x4096 pixels.
          - **Calculation:** 6 pieces x 170 tokens + 85 base tokens = **1,105 tokens**.
        
        ---
        
        ## Prompt Engineering
        GPT models are prompt-based, and prompt design directly influences the model's response.
        
        ### Tips:
        - Test and refine prompts for better results.
        - Consider the model's sensitivity to context.
        
        ---
        
        ## Available Models
        ### Text
        - GPT-3, GPT-3.5, GPT-4 (versions with fine-tuning available).
        
        ### Image
        - DALL-E Models: Generate images from text.
        
        ### Speech
        - Whisper: Transcribe and translate speech to text.
        - Text-to-Speech: Convert text to audio.
        
        ---
        
        ## Next Steps
        - Explore the available models in Azure OpenAI.
        - Learn more in the [official model guide](#).
        
        ----------------------
        
        # Overview of App Service
        **Article**  
        *10/16/2024*  
        **28 contributors**
        
        ---
        
        ## In this article
        - [Why use App Service?](#why-use-app-service)
        - [App Service on Linux](#app-service-on-linux)
        - [App Service Environment](#app-service-environment)
        - [Next steps](#next-steps)
        
        ---
        
        > **Note**  
        > Starting June 1, 2024, all newly created App Service applications will have the option to generate a unique default hostname using the naming convention `<app-name>-<random-hash>.<region>.azurewebsites.net`. Existing application names will remain unchanged.  
        > **Example:** `myapp-ds27dh7271aah175.westus-01.azurewebsites.net`  
        > For more details, see [Unique Default Hostname for App Service Resource](#).
        
        ---
        
        The **Azure App Service** is an HTTP-based service for hosting web applications, REST APIs, and mobile backends. It supports multiple languages, including **.NET, .NET Core, Java, Node.js, PHP, and Python**, running on both **Windows** and **Linux** environments.  
        Benefits include: **enhanced security, load balancing, auto-scaling, and automated management**, along with **DevOps** features.
        
        **Pricing model:**  
        You pay for the resources used by the **App Service Plan**. For more details, check [Overview of Azure App Service Plans](#).
        
        ---
        
        ## Why use App Service?
        
        ### Key features
        - **Wide variety of languages and frameworks:** ASP.NET, Java, Node.js, PHP, Python, among others.
        - **Managed environment:** Automatic OS and framework updates.
        - **Container support:** Custom images and Docker sidecars.
        - **DevOps optimization:** CI/CD with GitHub, Azure DevOps, and others.
        - **Global scalability:** Auto-scaling and high availability.
        - **Hybrid connections:** Integration with SaaS and on-premises data.
        - **Security and compliance:** ISO, SOC, and PCI.
        - **Authentication:** Supports Microsoft Entra ID, Google, Facebook, and more.
        - **Application templates:** Available in the Azure Marketplace.
        - **Tool integration:** Support for Visual Studio, IntelliJ, Maven, etc.
        - **Serverless code:** Azure Functions for on-demand executions.
        
        ---
        
        ## App Service on Linux
        
        App Service on Linux supports:
        - **Built-in languages:** Node.js, Java, PHP, Python, .NET Core.
        - **Custom images:** Option to create containers.
        
        ### Limitations
        - Not available in the **Shared** pricing tier.
        - **Azure Storage** with variable latency. For high performance, use custom containers.
        
        ---
        
        ## App Service Environment
        
        The **App Service Environment (ASE)** offers:
        - **Complete isolation.**
        - **Enhanced security.**
        - **High scale** for intensive workloads.
        
        > For more details, see the [comparison between ASE and App Service](#).
        
        ---
        
        ## Next steps
        Explore the advanced features of App Service and choose the ideal configuration for your application on Azure.
        
        ----------------------
        
        # What is Azure SQL?
        **Article**  
        *09/27/2024*  
        **20 contributors**
        
        ---
        
        ## In this article
        - [Overview](#overview)
        - [Service Comparison](#service-comparison)
        - [Comparison Table](#comparison-table)
        - [Cost](#cost)
        - [Administration](#administration)
        - [SLA (Service Level Agreement)](#sla-service-level-agreement)
        - [Time to move to Azure](#time-to-move-to-azure)
        - [Create and manage Azure SQL resources using the Azure portal](#create-and-manage-azure-sql-resources-using-the-azure-portal)
        
        ---
        
        ## Overview
        **Azure SQL** is a family of managed, secure, and intelligent products that use the SQL Server database engine in the Azure cloud. It offers easy migration, continuity with familiar tools, and leverages existing skills to maximize the potential of cloud solutions.
        
        The products include:
        1. **Azure SQL Database:** An intelligent, managed database service.
        2. **Azure SQL Managed Instance:** An intelligent instance-as-a-service for large-scale migrations.
        3. **SQL Server on Azure VMs:** Full control with lift-and-shift of SQL Server workloads.
        
        ---
        
        ## Service Comparison
        
        ### Available options:
        - **Azure SQL Database:** Best for modern cloud applications and agile development.
        - **Azure SQL Managed Instance:** Ideal for lift-and-shift with minimal changes.
        - **SQL Server on Azure VMs:** Perfect for OS-level access and full control.
        
        ---
        
        ## Comparison Table
        | **Feature**                   | **SQL Database**               | **SQL Managed Instance**        | **SQL Server on VMs**            |
        |-------------------------------|--------------------------------|---------------------------------|----------------------------------|
        | **Compatibility**             | High at database level        | High at instance level          | Total                            |
        | **SLA**                       | 99.995%                       | 99.99%                         | Up to 99.99%                    |
        | **Control**                   | Managed by Azure              | Partially managed               | Full control                    |
        | **Backups and recovery**      | Automatic                     | Automatic                      | Manual or automated             |
        | **Resource changes**          | Online                        | Online                         | Requires downtime               |
        | **Best use**                  | Modern applications           | Cloud migration                 | Complex workloads               |
        
        ---
        
        ## Cost
        Costs vary depending on the model (PaaS or IaaS) and chosen configurations.  
        - **Azure SQL Database and Managed Instance:** Hourly pricing with pre-configured, Azure-managed resources.
        - **SQL Server on VMs:** Full control over licensing and infrastructure costs.
        
        > To calculate costs, use the [Azure Pricing Calculator](https://azure.microsoft.com/en-us/pricing/calculator/).
        
        ---
        
        ## Administration
        - **Azure SQL Database and Managed Instance:** Simplified administration without the need to manage the OS or updates.
        - **SQL Server on VMs:** Full control over the OS and instance, but with greater administrative responsibility.
        
        ---
        
        ## SLA (Service Level Agreement)
        - **Azure SQL Database and Managed Instance:** 99.99% availability SLA.
        - **SQL Server on VMs:** SLA of 99.95% to 99.99%, depending on high-availability configuration.
        
        ---
        
        ## Time to move to Azure
        - **Azure SQL Database:** Ideal for new applications designed for the cloud.
        - **Azure SQL Managed Instance:** Simplifies migration with minimal changes.
        - **SQL Server on VMs:** Perfect for lift-and-shift migration without restructuring applications.
        
        ---
        
        ## Create and manage Azure SQL resources using the Azure portal
        The Azure portal allows you to create and manage Azure SQL resources such as:
        - SQL Databases
        - SQL Managed Instances
        - SQL Server Virtual Machines
        
        > **Note**  
        > Azure SQL is a family of services, not a single resource. To create new resources, select **+ Create** in the Azure portal.
        
        ---
        
        ## Related content
        - [Create an Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/)
        - [Migrate to Azure SQL](https://learn.microsoft.com/en-us/azure/sql-database/sql-database-migration-guidance)
        - [Azure SQL Pricing](https://azure.microsoft.com/en-us/pricing/details/sql-database/)
        """;
}