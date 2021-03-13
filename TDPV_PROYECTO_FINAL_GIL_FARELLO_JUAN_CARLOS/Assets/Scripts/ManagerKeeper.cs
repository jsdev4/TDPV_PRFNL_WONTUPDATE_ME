using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public static class ManagerKeeper
{
	private static Vector3 player_position;
	private static int lifes;
	private static float cells;
	private static float time_inside;
	private static int respawn_point_number;
	private static bool other_scene;
	private static bool mini_game_completed;
	private static int respawn_point_when_back;
	private static bool entering_some_place;
	private static int number_of_tries=2;
	private static int number_of_level = 0;
	public static void Set_values(Vector3 pos,int current_lifes, float current_cells,int rspwn)
	{
		player_position = pos;
		lifes = current_lifes;
		cells = current_cells;
		respawn_point_number = rspwn;
	}
	public static void Set_manager_script_info(float current_time_inside)
	{
		time_inside = current_time_inside;
	}
	public static void Is_in_other_scene(bool other)
	{
		other_scene = other;
	}
	public static bool Get_if_other_scene()
	{
		return other_scene;
	}
	public static Vector3 Get_old_players_position()
	{
		return player_position;
	}
	public static float Get_old_number_of_cells()
	{
		return cells;
	}
	public static int Get_old_number_of_lifes()
	{
		return lifes;
	}
	public static int Get_old_respawn_point()
	{
		return respawn_point_number;
	}
	public static float Get_old_time_script_inside()
	{
		return time_inside;
	}
	public static void Set_if_mini_game_was_completed(bool completed)
	{
		mini_game_completed = completed;
	}
	public static bool Get_if_mini_game_completed()
	{
		return mini_game_completed;
	}
	public static void Set_respawn_point(int point)
	{
		respawn_point_when_back = point;
	}
	public static int Get_respawn_point()
	{
		return respawn_point_when_back;
	}
	public static void Is_ed102_entering_some_place(bool entering)
	{
		entering_some_place = entering;
	}
	public static bool Return_if_is_ed102_enteroing_some_place()
	{
		return entering_some_place;
	}
	public static void Decrease_number_of_tries()
	{
		number_of_tries -= 1;
	}
	public static int Get_number_of_tries_availables()
	{
		return number_of_tries;
	}
	public static void Increase_number_of_level()
	{
		number_of_level += 1;
	}
	public static int Get_number_of_reached_level()
	{
		return number_of_level; 
	}
	public static void Reset_number_of_level()
	{
		number_of_level = 0;
	}
	public static void Set_current_level(int lvl)
	{
		number_of_level = lvl;
	}
}

