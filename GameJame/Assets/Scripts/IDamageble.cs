public interface IDamageble
{
    public float Health { get; set; }
    public void TakingDamage(float damage);
    public void Death();
}
