using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace IntroSE.Kanban.Frontend.Model
{

    public class BoardModel
    {
        IntroSE.Kanban.Backend.ServiceLayer.ServiceLayerFactory.GetInstance
        IntroSE.Kanban.Backend.BusinessLayer.BoardController bc;


        public BoardModel()
        {
            sbc = new Backend.ServiceLayer.BoardControllerService(bc);
        }


    }
}
