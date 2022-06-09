
namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DataAccessLayerFactory
    {
        private static DataAccessLayerFactory instance = null;
        private BoardControllerDTO BCDTO;
        private TaskControllerDTO taskControllerDTO;
        private UserControllerDTO userControllerDTO;
        private SQLExecuter executer;

        private DataAccessLayerFactory()
        {
            executer = new();
            BCDTO = new(executer);
            taskControllerDTO = new(executer);
            userControllerDTO = new(executer);
            
        }

        public BoardControllerDTO boardControllerDTO => BCDTO;
        public TaskControllerDTO TaskControllerDTO => taskControllerDTO;
        public UserControllerDTO UserControllerDTO => userControllerDTO;
        public SQLExecuter SQLExecuter => executer;

        public static DataAccessLayerFactory GetInstance()
        {
            if (instance == null) instance = new();
            return instance;
        }
    }
}
