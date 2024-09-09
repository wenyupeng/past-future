class Account:
    def __init__(self,name,startingBalance):
        self.name = name
        self.balance = startingBalance

    def print_account(self):
        print("%s $%.2f"% (self.name,self.balance))

    def deposit(self,amount):
        self.balance += amount

    def withdraw(self,amount):
        self.balance -= amount

class Program:
    def select_account(self):
        print('select an account')
        print('0 - account Fred')
        print('1 - account Jane')
        line = input("Select an account: ")
        return int(line)

    def main(self):
        account_1 = Account("Fred",100.0)
        account_1.print_account()

        account_2 = Account("Jane",80.0)
        account_2.print_account()

        while(True):
            print('select an option')
            print('0 - exit')
            print('1 - deposit')
            print('2 - withdraw')
            line = input("Select an option: ")
            num =int(line)
            if num ==0:
                break
            elif num ==1:
                num = self.select_account()
                account =  account_1 if num == 0 else account_2
                line = input("Enter amount to deposit: ")
                amount = float(line)
                account.deposit(amount)
            else:
                num = self.select_account()
                account = account_1 if num == 0 else account_2
                line = input("Enter amount to withdraw: ")
                amount = float(line)
                account.withdraw(amount)
            account_1.print_account()
            account_2.print_account()

program = Program()
program.main()
