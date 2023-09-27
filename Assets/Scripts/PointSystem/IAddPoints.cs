using System;
interface IAddPoints
{
    public event Action<int> OnPointsAdded;
}
