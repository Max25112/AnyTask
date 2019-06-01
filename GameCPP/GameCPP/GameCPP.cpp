#include<iostream>
#include <ctime>
using namespace std;
int bonusDamage = 0;
class enemy
{
public:
	string Name;
	virtual bool attack()const = 0;
	virtual void view_health()const = 0;
};
class Monster :public enemy
{

public:
	string Name = "Монстр";
	int chanceDodge = 5;
	int health = 200;
	int baseDamage = 25;
	bool attack()const { cout << "Монстр Атакует вас." << endl; return true; }
	void view_health()const { cout << "Здоровье монстра: " << health << endl; }
};
class Ghost :public enemy
{

public:
	string Name = "Призрак";
	int baseDamage = 24;
	int chanceDodge = 25;
	int health = 150;
	bool attack()const { cout << "Монстр Атакует вас." << endl; return true; }
	void view_health()const { cout << "Здоровье монстра: " << health << endl; }
};
class Hero
{
public:
	virtual bool appear()const = 0;
	virtual bool attack_sword()const = 0;
	virtual bool block()const = 0;
	virtual void view_health()const = 0;
};
class Player :public Hero
{
private:

public:
	int baseDamage = 35;
	int chanceDodge = 5;
	int health = 150;
	int damage_swor;
	int block_damage;
	void view_health()const { cout << "Здоровье монстра: " << health << endl; }
	bool appear()const { cout << "Перед вами монстр. Оно хочет убить вас. Выберете действие" << endl; return false; }
	bool attack_sword()const { cout << "Вы ударили мечом" << endl; return false; }
	bool block()const { cout << "Вы защишаетесь от удара монстра" << endl; return false; }
};
void view(int _enemyHealth, int _HeroHealth)
{
	cout << "Здоровье игрока: " << _HeroHealth << endl << "Здоровье монстра: " << _enemyHealth << endl;
}
int battle(const Monster& _enemy, const Player& _Hero)
{
	srand(time(0));
	cout << "Перед вами "<< _enemy.Name <<". Оно хочет убить вас. Выберете действие" << endl;
	int _HeroHealth = _Hero.health;
	int _enemyHealth = _enemy.health;
	bool _Heroblock_damage = false;
	int _Herodamage_sword;
	int _enemyAttack;
	while (_HeroHealth > 0 | _enemyHealth > 0)
	{
		_Heroblock_damage = false;
		_Herodamage_sword = 1 + rand() % 4 + _Hero.baseDamage + bonusDamage;
		_enemyAttack = 1 + rand() % 4 + _enemy.baseDamage;
		bool Heroatak = false;
		cout << "Ваши действия? 1) Атаковать мечом. 2)Парировать следующую атаку монстра." << endl;
		int x;
		cin >> x;
		switch (x)
		{
		case 1: _Hero.attack_sword(); Heroatak = true; break;
		case 2:_Hero.block(); _Heroblock_damage = rand() % 2 == 0;  break;
		}
		if (rand() % 100 <= _enemy.chanceDodge)
		{
			cout << "Враг уклонился" << endl;
		}
		else if (_Heroblock_damage | Heroatak)
		{
			_enemyHealth -= _Herodamage_sword;
		}

		int LvlDodge = rand() % 100;

		if (_enemyHealth < 0)
		{
			cout << "Вы выйграли" << endl;
			bonusDamage += 10;
			cout << "Ваш бонусный урон = " << bonusDamage << endl;
			return 1;
		}
		if (_Heroblock_damage)
		{
			cout << "Вы парировали атаку врага" << endl;
		}
		else if (rand() % 100 <= _Hero.chanceDodge)
		{
			cout << "Вы уклонились" << endl;
		}
		
		else if (!_Heroblock_damage)
		{
			_enemy.attack();
			_HeroHealth -= (_enemyAttack);
		}
		if (_HeroHealth < 0)
		{
			cout << "Потрачено" << endl;
			return 0;
		}
		view(_enemyHealth, _HeroHealth);
	}
}
int battle(const Ghost& _enemy, const Player& _Hero)
{
	srand(time(0));
	cout << "Перед вами " << _enemy.Name << ". Оно хочет убить вас. Выберете действие" << endl;
	int _HeroHealth = _Hero.health;
	int _enemyHealth = _enemy.health;
	bool _Heroblock_damage = false;
	int _Herodamage_sword;
	int _enemyAttack;
	while (_HeroHealth > 0 | _enemyHealth > 0)
	{
		_Heroblock_damage = false;
		_Herodamage_sword = 1 + rand() % 4 + _Hero.baseDamage + bonusDamage;
		_enemyAttack = 1 + rand() % 4 + _enemy.baseDamage;
		bool Heroatak = false;
		cout << "Ваши действия? 1) Атаковать мечом. 2)Парировать следующую атаку монстра." << endl;
		int x;
		cin >> x;
		switch (x)
		{
		case 1: _Hero.attack_sword(); Heroatak = true; break;
		case 2:_Hero.block(); _Heroblock_damage = rand() % 2 == 0;  break;
		}
		if (rand() % 100 <= _enemy.chanceDodge)
		{
			cout << "Враг уклонился" << endl;
		}
		else if (_Heroblock_damage | Heroatak)
		{
			_enemyHealth -= _Herodamage_sword;
		}

		int LvlDodge = rand() % 100;

		if (_enemyHealth < 0)
		{
			cout << "Вы выйграли" << endl;
			bonusDamage += 10;
			cout << "Ваш бонусный урон = " << bonusDamage << endl;
			return 1;
		}
		if (_Heroblock_damage)
		{
			cout << "Вы парировали атаку врага" << endl;
		}
		else if (rand() % 100 <= _Hero.chanceDodge)
		{
			cout << "Вы уклонились" << endl;
		}

		else if (!_Heroblock_damage)
		{
			_enemy.attack();
			_HeroHealth -= (_enemyAttack);
		}
		if (_HeroHealth < 0)
		{
			cout << "Потрачено" << endl;
			return 0;
		}
		view(_enemyHealth, _HeroHealth);
	}
}
int main()
{
	srand(time(0));
	bonusDamage = 0;
	int exit;
	int x;
	setlocale(LC_ALL, "Russian");
	cout << "Привет вы в квествой игре, чтобы выбрать действие напишите цифру действия.\n" << endl;
	Monster monster1;
	Player Hero1;
	Ghost ghost1;
	exit=battle(monster1, Hero1);
	if (exit == 1)
	{
		cout << "Вы убили монстра и получили доп. урон, но на вас напал призрак. Убейте его.\n";
		exit = battle(ghost1, Hero1);
	}
	if (exit == 0)
	{
		cout << "Вы проиграли. Если хотите сыграть сначала, введите 0\n";
		cin >> x;
		if (x==0)
		{
			main();
		}
	}
}
