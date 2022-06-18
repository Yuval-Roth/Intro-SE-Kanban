namespace IntroSE.Kanban.Backend.Utilities
{
    public class ValidateArguments
    {
        public static bool ValidateNotNull(object[] args)
        {
            foreach (object arg in args)
            {
                if (arg == null) return false;
            }
            return true;
        }
    }
}
