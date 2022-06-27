using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class TaskViewModel : Notifier
    {

        private Button backButton;
        private string email;
        private int boardId;
        private Model.Board board;
        private Model.BoardController boardController;

        public TaskViewModel(string email, int boardId)
        {
            backButton = new(306, 205, "Back", "Visible");
            this.email = email;
            this.boardId = boardId;
            boardController = new Model.BoardController();
            board = new (boardController.SearchBoard(email, boardId));
        }

        public string Email
        {
            set
            {
                this.email = value;
                RaisePropertyChanged("Email");
            }
            get { return email; }
        }

        public int BoardId
        {
            set
            {
                this.boardId = value;
                RaisePropertyChanged("BoardId");
            }
            get { return boardId; }
        }

        public Button BackButton => backButton;
    }
}
