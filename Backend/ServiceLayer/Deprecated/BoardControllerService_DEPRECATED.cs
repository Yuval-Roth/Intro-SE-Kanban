//using System;
//using System.Collections.Generic;

//namespace IntroSE.Kanban.Backend.ServiceLayer
//{
//    public class BoardControllerService
//    {
//        private BusinessLayer.BoardController boardController;

//        public BoardControllerService()
//        {
//            boardController = new BusinessLayer.BoardController();
//        }
//        public string CreateBoard(BusinessLayer.User user, String title)
//        {
//            try
//            {
//                boardController.CreateBoard(user, title);
//                return new Response(true, "Board created successfully").ToJson();
//            }
//            catch (Exception e)
//            { 
//                return new Response(false,e.Message).ToJson();
//            }
            
//        }
//        public string DeleteBoard(BusinessLayer.User user, String title)
//        {
//            return "";
//        }
//        public string GetAllTasksByState(BusinessLayer.User user,Enum state)
//        {
//            return "";
//        }
//        public string GetAllBoards(BusinessLayer.User user)
//        {
//            try
//            {
//                LinkedList<BusinessLayer.Board> boards = boardController.GetBoards(user);
//            }
//            catch(Exception e)
//            { }
//        }
//        public string SearchBoard(BusinessLayer.User user, String title)
//        {
//            try
//            {
//                BoardService boardService = new BoardService(boardController.SearchBoard(user, title));
                
//            }
//            catch (Exception e)
//            {

//            }
//        }
//    }
//}

