ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Countries] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Countries] FOREIGN KEY([nationCode])
REFERENCES [dbo].[Countries] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Drivers] FOREIGN KEY([teamCode])
REFERENCES [dbo].[Drivers] ([teamCode])
