using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class BoardPageViewModel : Notifier
    {
        private int BOARDTABLE_X = 10;
        private int BOARDTABLE_Y = 10;
        private int BOARDTABLE_WIDTH = 10;
        private int BOARDTABLE_HEIGHT = 129;

        private int CHOSENBOARD_X = 444;
        private int CHOSENBOARD_Y = 605;
        private int CHOSENBOARD_WIDTH = 640;
        private int CHOSENBOARD_HEIGHT = 55;

        private int SUBMIT_X = 662;
        private int SUBMIT_Y = 605;

        private TextBox chosenBoard;
        private GridView boardTable;
        private Button submit;
        

        public TextBox ChosenBoard => chosenBoard;
        public GridView BoardTable => boardTable;

        public Button Submit => submit;
        
        private Model.BoardController boardController = new Model.BoardController();

        //private string message;

        private string email;

        public BoardPageViewModel()
        {
            chosenBoard = new(CHOSENBOARD_X, CHOSENBOARD_Y, CHOSENBOARD_WIDTH, CHOSENBOARD_HEIGHT, "Insert your chosen boardId", "Vissible");
            submit = new(SUBMIT_X, SUBMIT_Y, "Submit", "vissible");
            this.email = email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void SetBoardTable()
        {
            string[] columnNames = { "BoardId", "BoardName", "Owner", "Joined", "BackLog", "InProgress", "Done" };
            try
            {
                LinkedList<Model.Board> boardList = boardController.GetBoards(email);
                boardTable = new(BOARDTABLE_X, BOARDTABLE_Y, BOARDTABLE_WIDTH, BOARDTABLE_HEIGHT, boardList.Count, columnNames);
            }
            catch(ArgumentException ex)
            {
                //message = ex.Message;
                RaisePropertyChanged("Message");
            }
        }

        public void AddBoards()
        {
            if(boardTable!= null)
            {
                LinkedList<Model.Board> boardList = boardController.GetBoards(email);
                int counter = 0;
                foreach(Model.Board board in boardList)
                {
                    boardTable.SetValue(counter,0,board.Id);
                    boardTable.SetValue(counter, 1, board.Title);
                    boardTable.SetValue(counter, 2, board.Owner);
                    boardTable.SetValue(counter, 3, board.Joined);
                    boardTable.SetValue(counter, 4, board.BackLog);
                    boardTable.SetValue(counter, 5, board.InProgress);
                    boardTable.SetValue(counter, 5, board.Done);
                    counter++;
                }
            }
        }

        public void ChosenBoard_Click()
        {
            if(chosenBoard.FirstClick)
            {
                chosenBoard.Text = "";
                chosenBoard.FirstClick = false;
            }
        }

        


        //public string Message
        //{
        //    get => message;
        //    set
        //    {
        //        this.message = value;
        //        RaisePropertyChanged("Message");
        //    }
        //}











    }
}
