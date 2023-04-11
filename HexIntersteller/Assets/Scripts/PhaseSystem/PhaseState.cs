#region Copyright Notice
// ******************************************************************************************************************
// 
// HexInterstellar.PhaseStates.cs © Shadow Wolf Development (SilentWolf6662 & Bambinidk) - All Rights Reserved
// Unauthorized copying of this file, via any medium is strictly prohibited
// Proprietary and confidential
// 
// This work is licensed under the Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License.
// To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-nd/3.0/
// 
// Created & Copyrighted @ 2023-04-11
// 
// ******************************************************************************************************************
#endregion
namespace HexInterstellar
{
	public enum PhaseState
	{
		StartPhase = 0,
		DrawPhase = 1,
		BuildPhase = 2,
		EndPhase = 3,
		StartCombatPhase = 4,
		CombatPhase = 5,
		AttackPhase = 6,
		DefendPhase = 7,
		EndCombatPhase = 8
	}
}
