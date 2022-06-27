using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Collections.ObjectModel;
using IntroSE.Kanban.Frontend.Model.DataClasses;

namespace IntroSE.Kanban.Frontend.Model
{

    public class BoardController
    {
        BoardControllerService bcs;

        public BoardController()
        {
            bcs = ServiceLayerFactory.GetInstance().BoardControllerService;
        }

        public ObservableCollection<Board> GetBoards(string email)
        {
            string Json = bcs.GetUserBoards(email);
            if(GetOperationState(Json) == true)
            {
                LinkedList<int> boards = Utilities.JsonEncoder.BuildFromJson<Utilities.Response<LinkedList<int>>>(Json).returnValue;
                ObservableCollection<Board> output = new ObservableCollection<Board>();
                foreach (int id in boards)
                {
                    string Json2 = bcs.GetBoardById(email, id);
                    if(GetOperationState(Json2) == true)
                    {
                        Board board = Utilities.JsonEncoder.BuildFromJson<Utilities.Response<Board>>(Json2).returnValue;
                        output.Add(board);
                    }  
                }
                        return output;
            }
            throw new ArgumentException("the user has no boards");             
        }

        public Board SearchBoard(string email, int boardId)
        {
            string Json = bcs.SearchBoard(email, boardId);
            Board board = Utilities.JsonEncoder.BuildFromJson<Utilities.Response<Board>>(Json).returnValue;
            return board;
        }

        private static bool GetOperationState(string json)
        {
            Utilities.Response<object> res = Utilities.JsonEncoder.BuildFromJson<Utilities.Response<object>>(json);
            return res.operationState;
        }


    }
}
