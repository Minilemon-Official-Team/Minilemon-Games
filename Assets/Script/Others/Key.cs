/// <summary>
/// Class untuk kunci
/// </summary>
public class Key : Collectible
{
    /// <summary>
    /// Ambil kunci
    /// </summary>
    public override void Pick()
    {
        Player.instance.inventory.AddKey();
        Destroy(gameObject);
    }
}
