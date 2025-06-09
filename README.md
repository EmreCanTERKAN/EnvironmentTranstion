# .NET Ortam Değişikliği (Environment Configuration)

Bu proje, .NET uygulamalarında farklı ortamlar (Environment) için `appsettings.{Environment}.json` dosyalarının publish sırasında otomatik olarak kopyalanmasını sağlar.


---

## 🚀 Çalıştırma Komutları (CLI)

### 1. Uygulamayı Çalıştırma (Run)

```bash
dotnet run --launch-profile Production 
dotnet publish -c Release -o C:\Users\PC\Desktop\1 -p:EnvironmentName=Production
```

### 2. Publish için csproj dosyasındaki ayar

```bash
<Target Name="OverrideAppSettings" AfterTargets="Publish">
	<PropertyGroup>
		<EnvironmentName Condition=" '$(EnvironmentName)' == '' ">Production</EnvironmentName>
		<SourceAppSettings>appsettings.$(EnvironmentName).json</SourceAppSettings>
		<DestinationAppSettings>$(PublishDir)appsettings.json</DestinationAppSettings>
	</PropertyGroup>

	<Message Text="Kopyalanıyor: $(SourceAppSettings) → $(DestinationAppSettings)" Importance="high" />

	<Copy SourceFiles="$(SourceAppSettings)"
		  DestinationFiles="$(DestinationAppSettings)"
		  SkipUnchangedFiles="false"
		  OverwriteReadOnlyFiles="true"
		  Condition="Exists('$(SourceAppSettings)')" />
</Target>
```
