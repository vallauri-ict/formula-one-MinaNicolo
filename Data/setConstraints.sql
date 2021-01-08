ALTER TABLE [dbo].[Driver]  WITH CHECK ADD CONSTRAINT [FK_Driver_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Countries] ([countryCode]);

ALTER TABLE [dbo].[Driver] WITH CHECK ADD CONSTRAINT [FK_Driver_Team] FOREIGN KEY([teamCode])
REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[Team]  WITH CHECK ADD CONSTRAINT [FK_Team_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Countries] ([countryCode]);

ALTER TABLE [dbo].[Circuit] WITH CHECK ADD CONSTRAINT [FK_Circuit_Countries] FOREIGN KEY([circuitNation])
REFERENCES [dbo].[Countries] ([countryCode]);

ALTER TABLE [dbo].[Race] WITH CHECK ADD CONSTRAINT [FK_Race_Circuit] FOREIGN KEY([circuitId])
REFERENCES [dbo].[Circuit] ([circuitId]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Team] FOREIGN KEY([teamId])
REFERENCES [dbo].[Team] ([teamCode]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Driver] FOREIGN KEY([driverId])
REFERENCES [dbo].[Driver] ([driverNumber]);

ALTER TABLE [dbo].[Result] WITH CHECK ADD CONSTRAINT [FK_Result_Race] FOREIGN KEY([raceId])
REFERENCES [dbo].[Race] ([idRace]);