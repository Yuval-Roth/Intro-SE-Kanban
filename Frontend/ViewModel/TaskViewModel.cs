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

        public TaskViewModel()
        {
            backButton = new(306, 205, "Back", "Visible");
            this.email = "";
            this.boardId = 0;
        }


        public void ReturnClick()
        {

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
