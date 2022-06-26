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


        private int CHOSENBOARD_X = 444;
        private int CHOSENBOARD_Y = 605;
        private int CHOSENBOARD_WIDTH = 640;
        private int CHOSENBOARD_HEIGHT = 55;

        private int SUBMIT_X = 662;
        private int SUBMIT_Y = 605;

        private int LABEL_X = 336;
        private int LABEL_Y = 654;

        private TextBox chosenBoard;
        private Button submit;
        private Label errorMessage;

        public string BoardName { get; set; }
        public int BoardID { get; set; }

        public ObservableCollection<Model.Board> BoardList { get; set; }

        public TextBox ChosenBoard => chosenBoard;
        public Button Submit => submit;

        public Label ErrorMessage => errorMessage;
        
        private Model.BoardController boardController = new Model.BoardController();

        private string email;

        public BoardPageViewModel()
        {
            chosenBoard = new(CHOSENBOARD_X, CHOSENBOARD_Y, CHOSENBOARD_WIDTH, CHOSENBOARD_HEIGHT, "Insert your chosen boardId", true);
            submit = new(SUBMIT_X, SUBMIT_Y, "Submit", true);
            errorMessage = new(LABEL_X, LABEL_Y, false);
            email = "mail@mail.com"/*email*/;
        }

        public void Initialize(string email)
        {
            this.email = email;
            BoardList = boardController.GetBoards(email);
            if(BoardList == null)
            {
                ErrorMessage.Content = "The user has no boards";
                errorMessage.Show();
            }
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
                if (int.TryParse(text, out _))
                {
                    int number = int.Parse(text);
                    if (number >= 0 && number <= BoardList.Count-1)
                    {
                        ErrorMessage.Content = "yessss";
                        errorMessage.Show();
                        return number;

                    }
                }
            }
            ErrorMessage.Content = "You must enter an exsisting board Id";
            errorMessage.Show();
            return -1;
        }
    }
}
