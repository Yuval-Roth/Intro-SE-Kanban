using IntroSE.Kanban.Frontend.Model;
using IntroSE.Kanban.Frontend.Utilities;
using IntroSE.Kanban.Frontend.ViewModel.UIElements;
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
        private Board board;
        private BoardController boardController;

        public TaskViewModel(/*string email, int boardId*/)
        {
            backButton = new(306, 205, "Back");
            boardController = new BoardController();
            board = boardController.SearchBoard(email, boardId);
        }

        public Button BackButton => backButton;
        public Board Board => board;


        public void Initialize(string email, int boardId)
        {
            this.email = email;
            board = boardController.SearchBoard(email,boardId);
            RaisePropertyChanged("Board");
        }

        //public string Email
        //{
        //    set
        //    {
        //        this.email = value;
        //        RaisePropertyChanged("Email");
        //    }
        //    get { return email; }
        //}

        //public int BoardId
        //{
        //    set
        //    {
        //        this.boardId = value;
        //        RaisePropertyChanged("BoardId");
        //    }
        //    get { return boardId; }
        //}

    }
}
