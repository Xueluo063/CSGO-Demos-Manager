﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSGO_Demos_Manager.Models;
using NPOI.SS.UserModel;

namespace CSGO_Demos_Manager.Services.Excel.Sheets.Single
{
	public class PlayersSheet : AbstractSingleSheet
	{
		public PlayersSheet(IWorkbook workbook, Demo demo)
		{
			Headers = new Dictionary<string, CellType>(){
				{ "Name", CellType.String },
				{ "SteamID", CellType.String },
				{ "Rank", CellType.Numeric },
				{ "Team", CellType.String },
				{ "Kills", CellType.Numeric },
				{ "Assists", CellType.Numeric },
				{ "Deaths", CellType.Numeric },
				{ "K/D", CellType.Numeric },
				{ "HS", CellType.Numeric },
				{ "HS%", CellType.Numeric },
				{ "Team kill", CellType.Numeric },
				{ "Entry kill", CellType.Numeric },
				{ "Bomb planted", CellType.Numeric },
				{ "Bomb defused", CellType.Numeric },
				{ "MVP", CellType.Numeric },
				{ "Score", CellType.Numeric },
				{ "Rating", CellType.Numeric },
				{ "KPR", CellType.Numeric },
				{ "APR", CellType.Numeric },
				{ "DPR", CellType.Numeric },
				{ "ADR", CellType.Numeric },
				{ "TDH", CellType.Numeric },
				{ "TDA", CellType.Numeric },
				{ "5K", CellType.Numeric },
				{ "4K", CellType.Numeric },
				{ "3K", CellType.Numeric },
				{ "2K", CellType.Numeric },
				{ "1K", CellType.Numeric },
				{ "1v1", CellType.Numeric },
				{ "1v2", CellType.Numeric },
				{ "1v3", CellType.Numeric },
				{ "1v4", CellType.Numeric },
				{ "1v5", CellType.Numeric },
				{ "VAC", CellType.Boolean },
				{ "OW", CellType.Boolean },
			};
			Demo = demo;
			Sheet = workbook.CreateSheet("Players");
		}

		public override async Task GenerateContent()
		{
			await Task.Factory.StartNew(() =>
			{
				var rowNumber = 1;

				foreach (PlayerExtended player in Demo.Players)
				{
					IRow row = Sheet.CreateRow(rowNumber);
					int columnNumber = 0;
					SetCellValue(row, columnNumber++, CellType.String, player.Name);
					SetCellValue(row, columnNumber++, CellType.String, player.SteamId.ToString());
					SetCellValue(row, columnNumber++, CellType.Numeric, player.RankNumberNew);
					SetCellValue(row, columnNumber++, CellType.String, player.TeamName);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.KillsCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.AssistCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.DeathCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, (double)player.KillDeathRatio);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.HeadshotCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.HeadshotPercent);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.TeamKillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.EntryKills.Count());
					SetCellValue(row, columnNumber++, CellType.Numeric, player.BombPlantedCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.BombDefusedCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.RoundMvpCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Score);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.RatingHltv);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.KillPerRound);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.AssistPerRound);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.DeathPerRound);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.AverageDamageByRoundCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.TotalDamageHealthCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.TotalDamageArmorCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.FiveKillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.FourKillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.ThreekillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.TwokillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.OnekillCount);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Clutch1V1Count);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Clutch1V2Count);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Clutch1V3Count);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Clutch1V4Count);
					SetCellValue(row, columnNumber++, CellType.Numeric, player.Clutch1V5Count);
					SetCellValue(row, columnNumber++, CellType.Boolean, player.IsVacBanned);
					SetCellValue(row, columnNumber, CellType.Boolean, player.IsOverwatchBanned);

					rowNumber++;
				}
			});
		}
	}
}