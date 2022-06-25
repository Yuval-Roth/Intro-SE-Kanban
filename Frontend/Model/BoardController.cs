using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace IntroSE.Kanban.Frontend.Model
{

    public class BoardController
    {
        BoardControllerService bcs;


        public BoardController()
        {
            bcs = ServiceLayerFactory.GetInstance().BoardControllerService;
        }

        public 


    }
}
