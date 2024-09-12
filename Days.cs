namespace Hobby_Animal
{
    public abstract class Days
    {
        public abstract void CareForTarantula(Tarantula x);
        public abstract void CareForHamster(Hamster x);
        public abstract void CareForCat(Cat x);
    }

    public class Joyful : Days
    {
        private Joyful() { }
        private static Joyful instance = null;
        public static Joyful Instance()
        {
            if (instance == null)
            {
                instance = new Joyful();
            }
            return instance;
        }

        public override void CareForCat(Cat x)
        {

            x.IncreaseBy(3);
        }

        public override void CareForHamster(Hamster x)
        {
            x.IncreaseBy(2);
        }

        public override void CareForTarantula(Tarantula x)
        {
            x.IncreaseBy(1);
        }
    }

    public class Usual : Days
    {
        private Usual() { }
        private static Usual instance = null;
        public static Usual Instance()
        {
            if (instance == null)
            {
                instance = new Usual();
            }
            return instance;
        }

        public override void CareForCat(Cat x)
        {
            x.IncreaseBy(3);
        }

        public override void CareForHamster(Hamster x)
        {
            x.DecreaseBy(3);
        }

        public override void CareForTarantula(Tarantula x)
        {
            x.DecreaseBy(2);
        }
    }

    public class Blue : Days
    {
        private Blue() { }
        private static Blue instance = null;
        public static Blue Instance()
        {
            if (instance == null)
            {
                instance = new Blue();
            }
            return instance;
        }

        public override void CareForCat(Cat cat)
        {
            cat.DecreaseBy(7);
        }

        public override void CareForHamster(Hamster hst)
        {
            hst.DecreaseBy(5);
        }

        public override void CareForTarantula(Tarantula tnt)
        {
            tnt.DecreaseBy(3);
        }
    }
}
