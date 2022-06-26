using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class BoardPageViewModel : Notifier
    {
        //private int BOARDTABLE_X = 10;
        //private int BOARDTABLE_Y = 10;
        //private int BOARDTABLE_WIDTH = 10;
        //private int BOARDTABLE_HEIGHT = 129;

        private int CHOSENBOARD_X = 444;
        private int CHOSENBOARD_Y = 605;
        private int CHOSENBOARD_WIDTH = 640;
        private int CHOSENBOARD_HEIGHT = 55;

        private int SUBMIT_X = 662;
        private int SUBMIT_Y = 605;

        private TextBox chosenBoard;
        private Button submit;

        public string BoardName { get; set; }
        public int BoardID { get; set; }

        public ObservableCollection<Model.Board> BoardList { get; set; }

        public TextBox ChosenBoard => chosenBoard;

        

        public Button Submit => submit;
        
        private Model.BoardController boardController = new Model.BoardController();

        private string email;

        public BoardPageViewModel()
        {
            chosenBoard = new(CHOSENBOARD_X, CHOSENBOARD_Y, CHOSENBOARD_WIDTH, CHOSENBOARD_HEIGHT, "Insert your chosen boardId", true);
            submit = new(SUBMIT_X, SUBMIT_Y, "Submit", true);
            email = "mail@mail.com"/*email*/;
        }

        public void Initialize(string email)
        {
            this.email = email;
            BoardList = boardController.GetBoards(email);
            RaisePropertyChanged("BoardList");
        }


        public void ChosenBoard_Click()
        {
            if(chosenBoard.FirstClick)
            {
                chosenBoard.Content = "";
                chosenBoard.FirstClick = false;
            }
        }

        public int Submit_Click()
        {
            if (chosenBoard.FirstClick == false && chosenBoard.Content != null)
            {
                string text = chosenBoard.Content;
                int numericValue;
                if (int.TryParse(text, out numericValue))
                {
                    int number = Int32.Parse(text);
                    if (number >= 0 && number <= BoardList.Count())
                    {
                        return number;

                    }
                }
            }
            return -1;
        }
    }
}
