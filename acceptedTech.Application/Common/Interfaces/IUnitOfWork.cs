﻿namespace acceptedTech.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
