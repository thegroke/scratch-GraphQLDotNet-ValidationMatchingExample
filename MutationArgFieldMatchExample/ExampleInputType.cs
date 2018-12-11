using GraphQL.Types;

namespace MutationArgFieldMatchExample
{
    class ExampleInputType : InputObjectGraphType
    {
        public ExampleInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("pleaseValidateMe");
        }
    }
}
