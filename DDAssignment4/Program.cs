using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAssignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            UserFactory staffFactory = new StaffFactory();
            User staffUser = new User(staffFactory);
            staffUser.ShowUserInfo();

            Console.WriteLine(Environment.NewLine);

            UserFactory administratorFactory = new AdministratorFactory();
            User administratorUser = new User(administratorFactory);
            administratorUser.ShowUserInfo();

            Console.WriteLine(Environment.NewLine);

            UserFactory patronFactory = new PatronFactory();
            User patronUser = new User(patronFactory);
            patronUser.ShowUserInfo();

            Console.ReadLine();
        }
    }

    class User {
        String type;
        Permission permission;
        Discount discount;

        public User(UserFactory factory) {
            type = factory.GetType().ToString().Substring(14);
            permission = factory.CreatPermission();
            discount = factory.CreateDiscount();
        }

        public void ShowUserInfo() {
            Console.WriteLine(type);
            permission.TypeOfPermission();
            discount.TypeOfDiscount();
        }
    }

    abstract class UserFactory {
        public abstract Permission CreatPermission();
        public abstract Discount CreateDiscount();
    }

    class StaffFactory : UserFactory
    {
        public override Permission CreatPermission()
        {
            return new StaffPermission();
        }

        public override Discount CreateDiscount()
        {
            return new StaffDiscount();
        }
    }

    class AdministratorFactory : UserFactory
    {
        public override Permission CreatPermission()
        {
            return new AdministratorPermission();
        }

        public override Discount CreateDiscount()
        {
            return new AdministratorDiscount();
        }
    }

    class PatronFactory : UserFactory
    {
        public override Permission CreatPermission()
        {
            return new PatronPermission();
        }

        public override Discount CreateDiscount()
        {
            return new PatronDiscount();
        }
    }

    abstract class Permission
    {
        public abstract void TypeOfPermission();
    }

    class StaffPermission : Permission
    {
        public override void TypeOfPermission()
        {
            Console.WriteLine("Staff Permission: Medium");
        }
    }

    class AdministratorPermission : Permission
    {
        public override void TypeOfPermission()
        {
            Console.WriteLine("Administrator Permission: High");
        }
    }

    class PatronPermission : Permission
    {
        public override void TypeOfPermission()
        {
            Console.WriteLine("Patron Permission: Low");
        }
    }

    abstract class Discount
    {
        public abstract void TypeOfDiscount();
    }

    class StaffDiscount : Discount
    {
        public override void TypeOfDiscount()
        {
            Console.WriteLine("Staff Discount: 5%");
        }
    }

    class AdministratorDiscount : Discount
    {
        public override void TypeOfDiscount()
        {
            Console.WriteLine("Administrator Discount: 5%");
        }
    }

    class PatronDiscount : Discount
    {
        public override void TypeOfDiscount()
        {
            Console.WriteLine("Patron Discount: 10%");
        }
    }
}
