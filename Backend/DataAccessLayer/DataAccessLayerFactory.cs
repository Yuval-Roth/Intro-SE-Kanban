using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer
{
    public class DataAccessLayerFactory
    {
        private static DataAccessLayerFactory instance = null;
        private BoardControllerDTO BCDTO;
        private BoardDTO boardDTO;
        private TaskDTO taskDTO;
        private UserDTO userDTO;
        private UserControllerDTO userControllerDTO;
        private SQLExecuter executer;

        private DataAccessLayerFactory()
        {
            BCDTO = new();
            boardDTO = new();
            taskDTO = new();
            userDTO = new();
            userControllerDTO = new();
            executer = new();
        }

        public BoardControllerDTO boardControllerDTO => BCDTO;
        public BoardDTO BoardDTO => boardDTO;
        public TaskDTO TaskDTO => taskDTO;
        public UserDTO UserDTO => userDTO;
        public UserControllerDTO UserControllerDTO => userControllerDTO;
        public SQLExecuter SQLExecuter => executer;

        public static DataAccessLayerFactory GetInstance()
        {
            if (instance == null) instance = new();
            return instance;
        }
    }
}
