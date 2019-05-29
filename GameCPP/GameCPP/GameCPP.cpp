#include<iostream>
#include <ctime>
using namespace std;
class enemy
{
public:
	virtual bool attack()const = 0;
	virtual void view_health()const = 0;
};
class Monster :public enemy
{

public:
	int health=300;
	int damage_sword=400;
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
	int health;
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
void battle(const enemy& _enemy, const Player& _Hero)
{
	srand(time(0));
	_Hero.appear();
	int _HeroHealth = 300;
	int _enemyHealth = 400;
	bool _Heroblock_damage = false;
	int _Herodamage_sword;
	int _enemyAttack;
	while (_HeroHealth > 0 | _enemyHealth > 0)
	{
		_Heroblock_damage = false;
		_Herodamage_sword = 1 + rand() % 4 + 35;
		_enemyAttack = 1 + rand() % 4 + 25;
		bool Heroatak = false;
		cout << "Ваши действия? 1) Атаковать мечом. 2)Парировать следующую атаку монстра." << endl;
		int x;
		cin >> x;
		switch (x)
		{
		case 1: _Hero.attack_sword(); Heroatak = true; break;
		case 2:_Hero.block(); _Heroblock_damage = rand() % 2 == 0;  break;
		}
		
		if (!_Heroblock_damage)
		{
			_enemy.attack();
			_HeroHealth -= (_enemyAttack);
		}

		if (_Heroblock_damage | Heroatak)
		{
			_enemyHealth -= _Herodamage_sword;
		}
		view(_enemyHealth, _HeroHealth);
		if (_enemyHealth < 0)
		{
			cout << "Вы выйграли" << endl;
			break;
		}
		if (_HeroHealth < 0)
		{
			cout << "Потраено" << endl;
			break;
		}
	}
}

int main()
{
	srand(time(0));
	setlocale(LC_ALL, "Russian");
	cout << "Привет вы в квествой игре \n чтобы выбрать действие напишите цифру действия \n А также можете написать 'help' чтобы вызвать помощь" << endl;
	Monster enemy1;
	Player Hero1;
	battle(enemy1, Hero1);
}
