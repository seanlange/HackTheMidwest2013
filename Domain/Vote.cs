namespace KcCauldronCapo.Model
{
    public partial class Vote
    {
        protected bool Equals(Vote other)
        {
            return DATE_ADDED_DT_TM.Equals(other.DATE_ADDED_DT_TM);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vote) obj);
        }

        public override int GetHashCode()
        {
            return DATE_ADDED_DT_TM.GetHashCode();
        }
    }
}