using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.Utilities;
using IntroSE.Kanban.Backend.Exceptions;
using IntroSE.Kanban.Backend.DataAccessLayer;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class TaskController
    {
        private readonly BoardController boardController;
        private readonly TaskControllerDTO TCDTO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Backend\\BusinessLayer\\TaskController.cs");
        public TaskController(BoardController BC)
        {
            boardController = BC;
            TCDTO = DataAccessLayerFactory.GetInstance().TaskControllerDTO;
        }

        public void AddTask(CIString email, CIString boardName, CIString title, CIString description, DateTime dueDate)
        {
            log.Debug("AddTask() for: " + title + ", " + description + ", " + dueDate);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task newTask = board.AddTask(title, dueDate, description);

                //DALL CALLS
                DataAccessLayerFactory.GetInstance().TaskControllerDTO.AddTask(board.Id, newTask.Id,
                    newTask.Title, newTask.Assignee, newTask.Description, newTask.CreationTime,
                    newTask.DueDate, (BoardColumnNames)newTask.State);

                log.Debug("AddTask() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("AddTask() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("AddTask() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("AddTask() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("AddTask() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("AddTask() failed: " + ex.Message);
                throw;
            }
        }



        public void RemoveTask(CIString email, CIString boardTitle, int taskId)
        {
            log.Debug("RemoveTask() taskId: " + taskId);
            try
            {
                Board board = boardController.SearchBoard(email, boardTitle);
                board.RemoveTask(taskId);

                //DAL CALLS
                TCDTO.RemoveTask(board.Id, taskId);

                log.Debug("RemoveTask() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("RemoveTask() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("RemoveTask() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("RemoveTask() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("RemoveTask() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("RemoveTask() failed: " + ex.Message);
                throw;
            }
        }


        public void AdvanceTask(CIString email, CIString boardName, int columnOrdinal, int taskId)
        {
            log.Debug("AdvanceTask() taskId: " + taskId);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task task = board.SearchTask(taskId);
                board.AdvanceTask(email, columnOrdinal, taskId);
                task.AdvanceTask(email);

                //DAL CALLS
                TCDTO.ChangeTaskState(task.BoardId, task.Id, (BoardColumnNames)task.State);

                log.Debug("AdvanceTask() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("AdvanceTask() failed: " + ex.Message);
                throw;
            }
        }

        public void UpdateTaskDescription(CIString email, CIString boardName, int columnOrdinal, int taskId, CIString description)
        {
            log.Debug("UpdateDescription() for taskId: " + taskId + ", email:" + email);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.UpdateDescription(email, description);

                //DAL CALLS
                TCDTO.ChangeDescription(task.Description, task.BoardId, task.Id);

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

                //DAL CALLS
                TCDTO.ChangeDueDate(task.DueDate, task.BoardId, task.Id);

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


        public void UpdateTaskTitle(CIString email, CIString boardName, int columnOrdinal, int taskId, CIString title)
        {
            log.Debug("UpdateTaskTitle() for taskId: " + taskId + ", email:" + email);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.UpdateTitle(email, title);

                //DAL CALLS
                TCDTO.ChangeTitle(task.Title, task.BoardId, task.Id);

                log.Debug("UpdateTaskTitle() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("UpdateTaskTitle() failed: " + ex.Message);
                throw;
            }
        }


        public void AssignTask(CIString email, CIString boardName, int columnOrdinal, int taskId, CIString emailAssignee)
        {
            log.Debug("AssignTask() for taskId: " + taskId + ", email:" + email);
            try
            {
                Board board = boardController.SearchBoard(email, boardName);
                if (board.Joined.Contains(email) == false)
                {
                    throw new AccessViolationException($"{emailAssignee} is not joined to the board and cannot be assigned to the task");
                }
                Task task = board.SearchTask(taskId, columnOrdinal);
                task.AssignTask(email, emailAssignee);

                //DAL CALLS
                TCDTO.ChangeAssignee(task.Assignee, task.BoardId, task.Id);

                log.Debug("AssignTask() success");
            }
            catch (NoSuchElementException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
            catch (AccessViolationException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
            catch (UserDoesNotExistException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
            catch (IndexOutOfRangeException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
            catch (ElementAlreadyExistsException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
            catch (UserNotLoggedInException ex)
            {
                log.Error("AssignTask() failed: " + ex.Message);
                throw;
            }
        }
    }

}

