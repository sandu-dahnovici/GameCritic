﻿using GameCritic.Application.Common.Dtos.GameAward;

namespace GameCritic.Application.Common.Dtos.Award
{
    public class AwardDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        //public IEnumerable<Gam> Games { get; set; }
    }
}