using GraphQL.Types;

namespace MutationArgFieldMatchExample
{
    class ExampleMutation : ObjectGraphType
    {
        public ExampleMutation()
        {
            FieldAsync<StringGraphType>(
              "exampleMutation",
              arguments: new QueryArguments(
                new QueryArgument<ExampleInputType> { Name = "theParameter" }
              )
            );
        }
    }
}
