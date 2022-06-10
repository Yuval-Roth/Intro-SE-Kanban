﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroSE.Kanban.Backend.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.DataAccessLayer.Tests
{
    [TestClass()]
    public class BoardControllerDTOTests
    {
        BoardControllerDTO boardControllerDTO;
        BoardControllerService service;
        UserService userService;
        BoardService boardService;
        SQLExecuter executer;
        BusinessLayer.BoardDataOperations dataOperations;


        public BoardControllerDTOTests()
        {
            Backend.BusinessLayer.BusinessLayerFactory.GetInstance().DataCenterManagement.DeleteData();
            ServiceLayerFactory.DeleteEverything();
            ServiceLayerFactory ServiceFactory = ServiceLayerFactory.GetInstance();
            DataAccessLayerFactory DataFactory = DataAccessLayerFactory.GetInstance();
            boardControllerDTO = DataFactory.BoardControllerDTO;
            service = ServiceFactory.BoardControllerService;
            userService = ServiceFactory.UserService;
            boardService = ServiceFactory.BoardService;
            executer = DataFactory.SQLExecuter;
            dataOperations = BusinessLayer.BusinessLayerFactory.GetInstance().BoardDataOperations;
        }

        [TestMethod()]
        public void AddBoardTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            userService.Register(email, password);
            string result = service.AddBoard(email, boardName);
            string query = $"SELECT * FROM Boards WHERE Email='{email}'";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        //remove board of owner
        [TestMethod()]
        public void RemoveBoardTestOwner()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            string result = service.RemoveBoard(email, boardName);
            string query = $"SELECT * FROM Boards WHERE Owner='{email} AND Title='{boardName}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        //remove board of joined
        [TestMethod()]
        public void RemoveBoardTestJoined()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            string email2 = "hadaspr100@gmail.com";
            string password2 = "Printz1234";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            userService.Register(email2, password2);
            int boardId = dataOperations.SearchBoardByEmailAndTitle(email, boardName).Id;
            boardService.JoinBoard(email2, boardId); 
            string result = service.RemoveBoard(email, boardName);
            string query = $"SELECT * FROM UserJoinedBoards WHERE BoardId='{boardId};";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (reader.Read()) Assert.Fail("No rows were fetched");
            }

        }

        [TestMethod()]
        public void JoinBoardTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string email2 = "hadaspr100@gmail.com";
            string password2 = "Printz1234";
            string boardName = "board1";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            int boardId = dataOperations.SearchBoardByEmailAndTitle(email, boardName).Id;
            userService.Register(email2, password2);
            string result = boardService.JoinBoard(email2, boardId);
            string query = $"SELECT * FROM UserJoinedBoards WHERE BoardId='{boardId};";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }

        }

        [TestMethod()]
        public void LeaveBoardTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string email2 = "hadaspr100@gmail.com";
            string password2 = "Printz1234";
            string boardName = "board1";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            int boardId = dataOperations.SearchBoardByEmailAndTitle(email, boardName).Id;
            userService.Register(email2, password2);
            ServiceLayerFactory.GetInstance().BoardService.JoinBoard(email2, boardId);
            string result = boardService.LeaveBoard(email2, boardId);
            string query = $"SELECT * FROM UserJoinedBoards WHERE BoardId='{boardId};";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void ChangeOwnerTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string email2 = "hadaspr100@gmail.com";
            string password2 = "Printz1234";
            string boardName = "board1";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            int boardId = dataOperations.SearchBoardByEmailAndTitle(email, boardName).Id;
            userService.Register(email2, password2);
            string result = boardService.ChangeOwner(email, email2,boardName);
            string query = $"SELECT * FROM Boards WHERE Owner='{email2}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
            }
        }

        [TestMethod()]
        public void LimitColumnTest()
        {
            string email = "printz@post.bgu.ac.il";
            string password = "Hadas1234";
            string boardName = "board1";
            userService.Register(email, password);
            service.AddBoard(email, boardName);
            string result = boardService.LimitColumn(email, boardName, 0, 20);
            string query = $"SELECT BackLogLimit FROM Boards WHERE BoardTitle='{boardName}";
            if (GetOperationState(result) == false) Assert.Fail("operationState is false");
            using (var reader = executer.ExecuteRead(query))
            {
                if (!reader.Read()) Assert.Fail("No rows were fetched");
                if (reader.GetInt32(0) != 20) Assert.Fail("change Limit incorrectly");
            }
        }
        private static bool GetOperationState(string json)
        {
            Response<object> res = JsonController.BuildFromJson<Response<object>>(json);
            if (res.operationState == true)
            {
                return true;
            }
            else return false;
        }


    }
}
