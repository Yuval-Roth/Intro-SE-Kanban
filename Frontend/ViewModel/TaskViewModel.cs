using IntroSE.Kanban.Frontend.Model;
using IntroSE.Kanban.Frontend.Model.DataClasses;
using IntroSE.Kanban.Frontend.Utilities;
using IntroSE.Kanban.Frontend.ViewModel.UIElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntroSE.Kanban.Frontend.ViewModel
{
    public class TaskViewModel : Notifier
    {
        private Window window;
        private Button backButton;
        private string email;
        private Board board;
        private BoardController boardController;

        public TaskViewModel()
        {
            backButton = new(306, 205, "Back");
            boardController = new BoardController();
        }

        public Button BackButton => backButton;
        public Board Board => board;


        public void Initialize(string email, int boardId)
        {
            this.email = email;
            board = boardController.SearchBoard(email,boardId);
            RaisePropertyChanged("Board");
        }

        public void SetWindow(Window window)
        {
            this.window = window;
        }
    }
}
