﻿using Extens.Models;

namespace Extens.Entities.Challenges;

public class CreateChallengeRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool IsPrivate { get; set; }
}