namespace SISGERED.shared.Entities
{
    internal class MaxlenghtAttribute : Attribute
    {
        private int v;
        private string errorMessage;

        public MaxlenghtAttribute(int v, string ErrorMessage)
        {
            this.v = v;
            errorMessage = ErrorMessage;
        }
    }
}