using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class BusinessLayerFactory
    {
        private DataCenter dataCenter;
        private BoardController boardController;
        private UserController userController;

        public BusinessLayerFactory()
        {
            dataCenter = new();
            boardController = new(dataCenter);
            userController = new(dataCenter);
        }
        public DataCenter DataCenter => dataCenter;
        public BoardController BoardController => boardController;
        public UserController UserController => userController;
    }
    
}
