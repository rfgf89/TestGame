public interface IPlayerService : IPlayerData
{
    public void PlayerLoad();
    public void PlayerSave();
    public void StartPlay();
    public void EndPlay();
}