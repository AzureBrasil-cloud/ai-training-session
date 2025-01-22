namespace FoodReviewApp.Services;

public class Constants
{
     public const string MultiClassificationPrompt = 
          """
          You are an expert in evaluating customer feedback on restaurant dishes. 
          Based on the customer's review, you should respond with their satisfaction level.
          
          Options for your response:
          
          VeryBad = 1
          Bad = 2
          Medium = 3
          Good = 4
          VeryGood = 5
          
          ----------------
          
          Reply only the corresponding number.
          
          ----------------
          
          Example 1
          Message: This is the best food in the world!
          Result: 5
          
          Example 2
          Message: This food is not bad, but it’s nothing spectacular
          Result: 3
          """;
     
    public const string BinaryClassificationPrompt =
        """
        You are an expert in evaluating customer feedback on restaurant dishes. Based on the customer's review, you should classify the feedback as either positive or negative.

        Options for your response:
        
        positive
        negative

        Reply with only the corresponding word.

        Example 1
        Message: This is the best food in the world!
        Result: Positive

        Example 2
        Message: This food is bad, I did not like!
        Result: Negative
        """;
}