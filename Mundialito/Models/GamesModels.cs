﻿using Mundialito.DAL.Games;
using Mundialito.DAL.Stadiums;
using Mundialito.DAL.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mundialito.Models
{
    public class GameViewModel
    {
        public GameViewModel(Game game)
        {
            GameId = game.GameId;
            HomeTeam = game.HomeTeam;
            AwayTeam = game.AwayTeam;
            Date = game.Date;
            HomeScore = game.HomeScore;
            AwayScore = game.AwayScore;
            CornersMark = game.CornersMark;
            CardsMark = game.CardsMark;
            Stadium = game.Stadium;
            IsOpen = game.IsOpen();
            IsPendingUpdate = game.IsPendingUpdate();
            IsBetResolved = game.IsBetResolved();
            Mark = game.Mark();
        }

        public int GameId { get; private set; }

        public Team HomeTeam { get; private set; }

        public Team AwayTeam { get; private set; }

        public DateTime Date { get; private set; }

        public int? HomeScore { get; private set; }

        public int? AwayScore { get; private set; }

        public String CornersMark { get; private set; }

        public String CardsMark { get; private set; }

        public Stadium Stadium { get; private set; }

        public DateTime CloseTime
        {
            get
            {
                return Date.Subtract(TimeSpan.FromMinutes(30));
            }
        }
       
        public Boolean IsOpen  { get; private set; }
        
        public Boolean IsPendingUpdate { get; private set; }

        public Boolean IsBetResolved { get; private set; }

        public String Mark { get; private set; }

    }

    /*
    public class GameStadiumViewModel
    {
        public GameStadiumViewModel(Stadium stadium)
        {
            StadiumId = stadium.StadiumId;
            Name = stadium.Name;
            City = stadium.City;
            Capacity = stadium.Capacity;
        }

        public int StadiumId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int Capacity { get; set; }
    }
    */

    public class NewGameModel
    {
        public int GameId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public Stadium Stadium { get; set; }

        [Required]
        public Team HomeTeam { get; set; }

        [Required]
        public Team AwayTeam { get; set; }

        public Boolean IsOpen { get; set; }

        public Boolean IsPendingUpdate { get; set; }
    }

    public class PutGameModel
    {
        public PutGameModel()
        {

        }

        public PutGameModel(Game game)
        {
            Date = game.Date;
            HomeScore = game.HomeScore;
            AwayScore = game.AwayScore;
            CornersMark = game.CornersMark;
            CardsMark = game.CardsMark;
            Stadium = game.Stadium;
            HomeTeam = game.HomeTeam;
            AwayTeam = game.AwayTeam;
        }

        public DateTime Date { get; set; }

        public int? HomeScore { get; set; }

        public int? AwayScore { get; set; }

        public String CornersMark { get; set; }

        public String CardsMark { get; set; }

        public Stadium Stadium { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

    }

    public class PutGameModelResult : PutGameModel
    {
        public PutGameModelResult(Game game, DateTime now) : base(game)
        {
            GameId = game.GameId;
            IsOpen = game.IsOpen(now);
            IsPendingUpdate = game.IsPendingUpdate(now);
            IsBetResolved = game.IsBetResolved(now);
            Mark = game.Mark(now);
        }

        public int GameId { get; private set; }

        public Boolean IsOpen { get; private set; }

        public Boolean IsPendingUpdate { get; private set; }

        public Boolean IsBetResolved { get; private set; }

        public String Mark { get; private set; }

    }
}