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
            catch (UserDoesNotExistException ex)
            {
                log.Error("UpdateDescription() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("SearchBoard() failed: " + ex.Message);
                throw;
            }

            catch (NoSuchElementException ex)
            {
                log.Error("UpdateDescription() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("UpdateDescription() failed: " + ex.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("UpdateDescription() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("UpdateDescription() failed: " + ex.Message);
                throw;
            }

        }

        public void UpdateTaskDueDate(CIString email, CIString boardName, int columnOrdinal, int taskId, DateTime dueDate)
        {
            log.Debug("UpdateDueDate() for taskId: " + taskId + ", email:" + email);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.UpdateDueDate(email, dueDate);
                log.Debug("UpdateTaskDueDate() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("UpdateDueDate() failed: " + ex.Message);
                throw;
            }
        }

    }
}
