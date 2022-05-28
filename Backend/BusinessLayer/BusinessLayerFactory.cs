using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BusinessLayerFactory
    {
        private static BusinessLayerFactory instance = null;

        private DataCenter dataCenter;
        private BoardController boardController;
        private UserController userController;
        //private BoardMembersPermissions BMP;

        private BusinessLayerFactory()
        {
            dataCenter = new();
            boardController = new(dataCenter);
            userController = new(dataCenter);
            //BMP = new(dataCenter,boardController);
        }
        public DataCenter DataCenter => dataCenter;
        public BoardController BoardController => boardController;
        public UserController UserController => userController;
        //public BoardMembersPermissions BoardMembersPermissions => BMP;

        public static BusinessLayerFactory GetInstance()
        {
            if (instance == null) instance = new();
            return instance;
        }
        

    }
    
}
