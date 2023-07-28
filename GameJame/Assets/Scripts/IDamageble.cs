public interface IDamageble
{
    public int Health { get; set; }
    public void TakingDamage(int damage);
    public void Death();
}
