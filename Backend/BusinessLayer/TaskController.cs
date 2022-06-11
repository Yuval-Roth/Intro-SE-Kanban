using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.Utilities;
using IntroSE.Kanban.Backend.Exceptions;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class TaskController
    {
        private readonly BoardController boardController;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\TaskController.cs");
        public TaskController(BoardController BC)
        {
            boardController = BC;
        }

        public void UpdateTaskDescription(CIString email, CIString boardName, int columnOrdinal, int taskId, CIString description)
        {
            log.Debug("UpdateDescription() for taskId: " + taskId + ", email:" + email);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.UpdateDescription(email, description);
                log.Debug("UpdateDescription() success");
            }
            catch (UserDoesNotExistException e)
            {
                log.Error("UpdateDescription() failed: " + e.Message);
                throw;
            }
            catch (UserNotLoggedInException e)
            {
                log.Error("SearchBoard() failed: " + e.Message);
                throw;
            }

            catch (NoSuchElementException ex)
            {
                log.Error("UpdateDescription() failed: " + e.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("UpdateDescription() failed: " + e.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("UpdateDescription() failed: " + e.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("UpdateDescription() failed: " + e.Message);
                throw;
            }

        }

    }
}
