﻿using NetCoreGraphSQL.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreGraphSQL.Shared.RepoDefinitions
{
    public interface IApplicantRepository
    {
        List<Applicant> All(int applicationId);
    }
}
