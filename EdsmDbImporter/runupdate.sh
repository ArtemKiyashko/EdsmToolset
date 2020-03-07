cd ~/ed_data
wget https://www.edsm.net/dump/systemsWithCoordinates7days.json.gz \
&& wget https://www.edsm.net/dump/bodies7days.json.gz \
&& gunzip -f systemsWithCoordinates7days.json.gz \
&& gunzip -f bodies7days.json.gz

cd ~/edimport_sources
dotnet run -- -a import -s ../ed_data/systemsWithCoordinates7days.json -b ../ed_data/bodies7days.json
