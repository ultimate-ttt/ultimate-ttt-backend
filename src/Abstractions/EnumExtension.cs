namespace UltimateTicTacToe.Abstractions
{
    public static class EnumExtension{
        public static TileValue ToTileValue(this Player player){
            if(player == Player.Cross){
                return TileValue.Cross;
            }
            return TileValue.Circle;
        }
    }
}
