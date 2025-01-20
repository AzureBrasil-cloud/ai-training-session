using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

const string systemMessage = """
    "You are a helpful RH assistant that create  Input summarizations.
    Your task is to summarize the person's  Input using the follow format:

    'Summary: <short summary about the person>. Hard skills: <hard skills>. Soft skills: <soft skills>. Languages: <languages>. Jobs: <Professional jobs>.'

    ------
    Note: Some of the inputs may not include all information, such as languages or professional jobs. In Summary, you must put 'None' in the value'.
    Note: Outputs only the summarized information. Do not include the input text in the output.
    ---------

    Example 1.
    Input -> John Doe, a 28-year-old Frontend Developer with experience at TechCorp and WebSolutions, specializes in delivering responsive, high-performing interfaces using HTML, CSS, and JavaScript. Fluent in both English and Spanish, he excels at collaborating with diverse teams to create clean, maintainable code leveraging frameworks like React and Angular. John’s hard skills include version control (Git), RESTful API integration, and agile methodologies, while his soft skills—such as problem-solving, adaptability, and strong communication—enable him to consistently align development efforts with business objectives and user needs.
    Output ->  Summary: John Doe is a 28-year-old Frontend Developer recognized for creating responsive, high-performing user interfaces. Hard skills: HTML, CSS, JavaScript, React, Angular, Git, RESTful API integration, agile methodologies. Soft skills: Problem-solving, adaptability, strong communication. Languages: English, Spanish. Jobs: TechCorp, WebSolutions.

    Example 2.
    Input -> Talles Silva, a 30-year-old Backend Developer with experience at Skyline Systems and CodeForge Studios, specializes in building scalable APIs, optimizing database performance, and implementing cloud-based solutions. Proficient in C#, .NET Core, PostgreSQL, and Azure, he delivers efficient, maintainable code while collaborating effectively with diverse teams. Talles excels in problem-solving, leadership, and aligning technical solutions with business goals.
    Output -> Summary: Talles Silva is a 30-year-old Backend Developer recognized for building scalable APIs, optimizing database performance, and implementing cloud-based solutions. Hard skills: C#, .NET Core, PostgreSQL, Azure. Soft skills: Problem-solving, leadership, effective collaboration, alignment with business goals. Languages: None. Jobs: Skyline Systems, CodeForge Studios.

    Example 3.
    Input -> Lucas Ferreira, a 35-year-old Database Administrator with extensive experience at DataSphere Innovations and Nexus Analytics, excels in managing and optimizing database systems for high-performance applications. With deep expertise in PostgreSQL, SQL Server, and MySQL, Lucas has implemented advanced indexing strategies, optimized complex queries, and ensured database scalability to handle enterprise workloads. He is also skilled in managing high-availability clusters, performing seamless data migrations, and automating routine database tasks using scripts and monitoring tools. Fluent in Portuguese, English, and Italian, Lucas works effectively with diverse teams to deliver reliable, secure, and well-documented database environments. His experience extends to integrating cloud databases with platforms like Azure and AWS, leveraging tools such as Power BI for actionable analytics, and ensuring compliance with data governance standards. Known for his problem-solving abilities and proactive approach, Lucas consistently aligns database solutions with organizational objectives, enhancing operational efficiency and data reliability.
    Output ->  Summary: Lucas Ferreira is a 35-year-old Database Administrator recognized for managing and optimizing database systems to ensure high performance and reliability. Hard skills: PostgreSQL, SQL Server, MySQL, advanced indexing strategies, complex queries optimization, high-availability clusters management, data migrations, scripting, monitoring tools, Azure, AWS, Power BI, data governance compliance. Soft skills: Problem-solving, proactive approach, effective collaboration. Languages: Portuguese, English, Italian. Jobs: DataSphere Innovations, Nexus Analytics.

    Example 4.
    Input -> Alex Morgan, a 29-year-old Data Scientist with experience at DataPulse Analytics and NextGen Insights, is adept at transforming complex data into actionable insights. Specializing in Python, R, machine learning algorithms, and data visualization, Alex has successfully developed predictive models that increased operational efficiency by 30% and improved customer satisfaction through targeted recommendations. Fluent in English and French, Alex collaborates seamlessly with cross-functional teams to deliver solutions aligned with strategic business objectives. Known for analytical thinking, curiosity, and strong communication skills, Alex drives data-driven decision-making while consistently optimizing processes for scalability.
    Output -> Alex Morgan is a 29-year-old Data Scientist known for developing predictive models and actionable insights. Hard skills: Python, R, machine learning, data visualization. Soft skills: Analytical thinking, curiosity, strong communication. Languages: English, French. Jobs: DataPulse Analytics, NextGen Insights.

    Example 5.
    Input -> Emily Carter, a 41-year-old Project Manager recognized for overseeing large-scale e-commerce implementations, excels in budget management, stakeholder engagement, and risk assessment. With expertise in Agile methodologies, Scrum framework, and software project lifecycle, Emily efficiently leads cross-functional teams to meet deadlines and ensure project success. She is highly effective at resolving conflicts, prioritizing tasks, and aligning project goals with business objectives. Emily’s proactive communication and problem-solving skills result in streamlined processes and improved client satisfaction.
    Output -> Emily Carter is a 41-year-old Project Manager known for successfully leading e-commerce implementations. Hard skills: Agile methodologies, Scrum, software project lifecycle, budget management, risk assessment. Soft skills: Conflict resolution, task prioritization, proactive communication, problem-solving. Languages: None. Jobs: None.
    """;

var resume = """
             Ethan Reynolds is a 29-year-old Full Stack Developer with over five years of experience in designing, building, and maintaining high-traffic web applications using Node.js, React, and PostgreSQL. He has driven key projects at ByteLeap and CloudGrid, emphasizing clean coding practices, agile collaboration, and user-focused solutions that scale efficiently under peak demands. Known for his strong communication skills, Ethan excels at translating complex technical requirements into clear, actionable strategies while working seamlessly with cross-functional teams. Committed to continuous learning and fluent in English, he stays at the forefront of emerging technologies and industry trends, ensuring that the applications he develops consistently meet evolving business and user needs.
             """;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

IConfiguration config = builder.Build();

string key = config["AzureOpenAi:Key"]!;
string model = config["AzureOpenAi:Model"]!;
string url = config["AzureOpenAi:Endpoint"]!;

AzureOpenAIClient azureClient = new(
    new Uri(url),
    new ApiKeyCredential(key));

ChatClient chatClient = azureClient.GetChatClient(model);

ChatCompletion completion = chatClient.CompleteChat(
[
    new SystemChatMessage(systemMessage),
    new UserChatMessage(resume)
]);

Console.WriteLine($"Output: {completion.Content[0].Text}");
Console.WriteLine($"Total of tokens: {completion.Usage.TotalTokenCount}");