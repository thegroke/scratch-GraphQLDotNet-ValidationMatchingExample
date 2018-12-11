using GraphQL;
using GraphQL.Types;
using GraphQL.Validation;
using System;
using System.Linq;

namespace MutationArgFieldMatchExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var schema = new Schema()
            {
                Mutation = new ExampleMutation()
            };

            var res = schema.Execute(_ =>
            {
                _.Query = @"
                    mutation {
                      exampleMutation(theParameter: {
                        pleaseValidateMe: ""foo""
                      })
                    }";
                _.ValidationRules =
                    new IValidationRule[]
                    {
                        new ValidationRuleA(),
                        new ValidationRuleB()
                    }
                    .Concat(DocumentValidator.CoreRules());
            });

            Console.WriteLine("Press a key to quit");
            Console.ReadKey();
        }
    }
}
