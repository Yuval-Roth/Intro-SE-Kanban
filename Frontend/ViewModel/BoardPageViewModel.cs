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
        private int BOARDTABLE_HEIGHT = 65;

        private int CHOSENBOARD_X = 333;
        private int CHOSENBOARD_Y = 334;
        private int CHOSENBOARD_WIDTH = 383;
        private int CHOSENBOARD_HEIGHT = 21;

        private TextBox chosenBoard;
        private GridView boardTable;
        

        public TextBox ChosenBoard => chosenBoard;
        public GridView BoardTable => boardTable;
        
        private Model.BoardController boardController = new Model.BoardController();

        private string message;

        public BoardPageViewModel()
        {
            chosenBoard = new(CHOSENBOARD_X, CHOSENBOARD_Y, CHOSENBOARD_WIDTH, CHOSENBOARD_HEIGHT, "Insert your chosen boardId", false);
            
        }

        public void setBoardTable(string email)
        {
            string[] columnNames = { "BoardId", "BoardName", "Owner", "Joined", "BackLog", "InProgress", "Done" };
            try
            {
                LinkedList<Model.Board> boardList = boardController.GetBoards(email);
                boardTable = new(BOARDTABLE_X, BOARDTABLE_Y, BOARDTABLE_WIDTH, BOARDTABLE_HEIGHT, boardList.Count, columnNames);
            }
            catch(ArgumentException ex)
            {
                message = ex.Message;
                RaisePropertyChanged("Message");
            }
        }
  
        
        public string Message
        {
            get => message;
            set
            {
                this.message = value;
                RaisePropertyChanged("Message");
            }
        }







    }
}
