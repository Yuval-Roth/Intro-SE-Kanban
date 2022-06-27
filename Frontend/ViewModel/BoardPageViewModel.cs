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
        private static readonly int Height = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
        private static readonly int Width = (int)System.Windows.SystemParameters.PrimaryScreenWidth;

        private int CHOSENBOARD_X = Width/2 -700;
        private int CHOSENBOARD_Y = Height/2 + 20;


        private int SUBMIT_X = Width / 2 - 300;
        private int SUBMIT_Y = Height / 2 + 20;

        private int LABEL_X = Width / 2 -600;
        private int LABEL_Y = Height / 2- 100;

        private int CHOOSEYOURBOARD_X = Width / 2 - 300;
        private int CHOOSEYOURBOARD_Y = Height / 2 + 150;

        private int LOGOUT_X = Width / 2 - 500;
        private int LOGOUT_Y = Height / 2 + 150;

        private TextBox chosenBoard;
        private Button submit;
        private Button logout;
        private Label errorMessage;
        private Label chooserYourBoard;

        public string BoardName { get; set; }
        public int BoardID { get; set; }

        public ObservableCollection<Model.Board> BoardList { get; set; }

        public TextBox ChosenBoard => chosenBoard;
        public Button Submit => submit;

        public Label ErrorMessage => errorMessage;

        public Label ChooseYourBoard => chooserYourBoard;

        public Button Logout => logout;
        
        private Model.BoardController boardController = new Model.BoardController();

        private string email;

        public BoardPageViewModel()
        {
            chosenBoard = new(CHOSENBOARD_X, CHOSENBOARD_Y, 0, 0, "Insert your chosen boardId", true);
            submit = new(SUBMIT_X, SUBMIT_Y, "Submit");
            errorMessage = new(LABEL_X, LABEL_Y, false);
            chooserYourBoard = new(CHOOSEYOURBOARD_X, CHOOSEYOURBOARD_Y, true);
            logout = new(LOGOUT_X, LOGOUT_Y, "LogOut");
            email = "mail@mail.com"/*email*/;
            UpdateMargins();
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
                        return number;
                    }
                }
            }
            ErrorMessage.Content = "You must enter an exsisting board Id";
            errorMessage.Show();
            return -1;
        }

        public void UpdateMargins()
        {
            chosenBoard.X = CHOSENBOARD_X;
            chosenBoard.Y = CHOSENBOARD_Y;
            submit.X = SUBMIT_X;
            submit.Y = SUBMIT_Y;
            errorMessage.X = LABEL_X;
            errorMessage.Y = LABEL_Y;
            logout.X = LOGOUT_X;
            logout.Y = LOGOUT_Y;
            chooserYourBoard.X = CHOOSEYOURBOARD_X;
            chooserYourBoard.Y = CHOOSEYOURBOARD_Y;
        }
    }
}
