using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.ServiceLayer;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using IntroSE.Kanban.Frontend.Utilities;

namespace IntroSE.Kanban.Frontend.Model
{

    public class BoardController
    {
        BoardControllerService bcs;
        GradingService gs;

        public BoardController()
        {
            gs = new();
            gs.LoadData();
            gs.Login("mail@mail.com", "Password1");
            bcs = ServiceLayerFactory.GetInstance().BoardControllerService;
        }

        public ObservableCollection<Board> GetBoards(string email)
        {
            string Json = bcs.GetUserBoards(email);
            if(GetOperationState(Json) == true)
            {
                LinkedList<int> boards = JsonEncoder.BuildFromJson<Response<LinkedList<int>>>(Json).returnValue;
                ObservableCollection<Board> output = new ObservableCollection<Board>();
                foreach (int id in boards)
                {
                    string Json2 = bcs.GetBoardById(email, id);
                    if(GetOperationState(Json2) == true)
                    {
                        Board board = JsonEncoder.BuildFromJson<Response<Board>>(Json2).returnValue;
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
            Board board = JsonEncoder.BuildFromJson<Response<Board>>(Json).returnValue;
            return board;
        }

        private static bool GetOperationState(string json)
        {
            Response<object> res = JsonEncoder.BuildFromJson<Response<object>>(json);
            return res.operationState;
        }


    }
}
