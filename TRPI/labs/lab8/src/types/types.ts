export type StateType = {
    filterText: string,
    inStockOnly: boolean,
    onFilterTextChange : (text : string) => void,
    onInStockChange : (status : boolean) => void,
};
export interface IProduct{
    category: string;
    price: string;
    stocked: boolean;
    name: string;
}
export type ProductTableType = {
    products: IProduct[]
    state: StateType
}
export type ProductCategoryRowType={
    category:string
}
export type ProductRowType = {
    product : IProduct
}